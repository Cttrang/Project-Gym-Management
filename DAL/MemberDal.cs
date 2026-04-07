using desktopapp_GYM.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desktopapp_GYM.DAL
{
    public class MemberDal
    {
        DataConnection dc = new DataConnection();
        public int GetTotalMembers()
        {
            string sql = "SELECT COUNT(*) FROM MEMBERS";
            using (SqlConnection con = dc.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        //kiểm tra quá hạn ở database và chỉnh status member nếu member đã hết hạn
        public int UpdateExpiredStatus()
        {
            string sql = @"
                -- 1. Khóa những người hết hạn
                UPDATE MEMBERS SET STATUS = 'Inactive' 
                WHERE MEMBERID IN (
                    SELECT MEMBERID FROM REGISTRATIONS 
                    WHERE ENDDATE < GETDATE()
                ) AND STATUS = 'Active';

                -- 2. Mở khóa những người đã gia hạn (quan trọng!)
                UPDATE MEMBERS SET STATUS = 'Active' 
                WHERE MEMBERID IN (
                    SELECT MEMBERID FROM REGISTRATIONS 
                    WHERE ENDDATE >= GETDATE()
                ) AND STATUS = 'Inactive';";
            using (SqlConnection con = dc.GetConnection())
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        // Thực thi câu lệnh UPDATE (trả về số dòng bị tác động)
                        return cmd.ExecuteNonQuery();

                        // Huy có thể dùng Console.WriteLine hoặc Debug để kiểm tra nếu cần
                        // Console.WriteLine($"Đã cập nhật {rowsAffected} hội viên hết hạn.");
                    }
                }
                catch (Exception ex)
                {
                    // Ghi log lỗi nếu có (Huy có thể dùng MessageBox hoặc ném Exception ra BLL)
                    throw new Exception("Lỗi khi cập nhật trạng thái hết hạn: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public DataTable GetExpiringMembers()
        {
            //Ép kiểu số ngày thành chuỗi ngay trong SQL để C# không bị lỗi format
            string sql = @"SELECT TOP 5 
                    m.FullName, 
                    r.EndDate,
                    CAST(DATEDIFF(day, CAST(GETDATE() AS DATE), r.EndDate) AS NVARCHAR(50)) AS DaysStatus
                   FROM MEMBERS m 
                   JOIN REGISTRATIONS r ON m.MemberID = r.MemberID 
                   WHERE r.EndDate <= DATEADD(day, 7, GETDATE())
                   ORDER BY r.EndDate ASC";

            DataTable dt = new DataTable();
            using (SqlConnection con = dc.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dt);
            }
            return dt;

        }

        public DataTable GetAllEveryone()
        {
            string sql = @"
        -- 1. USERS
        SELECT 
            U.USERID AS ID, U.USERNAME AS FULLNAME, U.ROLE AS TYPE, '' AS PHONE, 
            NULL AS JOINDATE, NULL AS REGDATE, NULL AS ENDDATE, 
            0 AS TOTALAMOUNT, '' AS PAYMENTSTATUS, NULL AS PACKAGEID, NULL AS TRAINERID,
            '' AS STATUS, '' AS GHICHU
        FROM USERS U

        UNION ALL

        -- 2. TRAINERS
        SELECT 
            T.TRAINERID AS ID, T.FULLNAME, N'Trainer' AS TYPE, T.PHONE, 
            NULL AS JOINDATE, NULL AS REGDATE, NULL AS ENDDATE, 
            0 AS TOTALAMOUNT, '' AS PAYMENTSTATUS, NULL AS PACKAGEID, T.TRAINERID AS TRAINERID,
            T.STATUS, T.SPECIALTY AS GHICHU
        FROM TRAINERS T

        UNION ALL

        -- 3. MEMBERS (Thêm Package và Trainer ID từ bảng Registrations)
        SELECT 
            M.MEMBERID AS ID, M.FULLNAME, N'Member' AS TYPE, M.PHONE, 
            M.JOINDATE, R.REGDATE, R.ENDDATE, 
            ISNULL(R.TOTALAMOUNT, 0) AS TOTALAMOUNT, R.PAYMENTSTATUS,
            R.PACKAGEID, R.TRAINERID, M.STATUS, 
            (SELECT N'Đã đăng ký: ' + CAST(COUNT(*) AS NVARCHAR) + N' gói' 
            FROM REGISTRATIONS 
            WHERE MEMBERID = M.MEMBERID) AS GHICHU
            FROM MEMBERS M
            LEFT JOIN (
        SELECT * FROM REGISTRATIONS
        WHERE REGID IN (
            SELECT MAX(REGID) 
            FROM REGISTRATIONS 
            GROUP BY MEMBERID
            )
        )  R ON M.MEMBERID = R.MEMBERID
        LEFT JOIN TRAINERS T ON R.TRAINERID = T.TRAINERID";

            DataTable dt = new DataTable();
            using (SqlConnection con = dc.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable SearchEveryone(string keyword)
        {
            string sql = @"
        SELECT U.USERID AS ID, U.USERNAME AS FULLNAME, U.ROLE AS TYPE, '' AS PHONE, NULL AS JOINDATE, NULL AS REGDATE, NULL AS ENDDATE, 0 AS TOTALAMOUNT, '' AS PAYMENTSTATUS, NULL AS PACKAGEID, NULL AS TRAINERID, '' AS STATUS, '' AS GHICHU
        FROM USERS U WHERE U.USERNAME LIKE @KEY
        UNION ALL
        SELECT T.TRAINERID AS ID, T.FULLNAME, N'Trainer' AS TYPE, T.PHONE, NULL AS JOINDATE, NULL AS REGDATE, NULL AS ENDDATE, 0 AS TOTALAMOUNT, '' AS PAYMENTSTATUS, NULL AS PACKAGEID, T.TRAINERID AS TRAINERID, T.STATUS, T.SPECIALTY AS GHICHU
        FROM TRAINERS T WHERE T.FULLNAME LIKE @KEY OR T.PHONE LIKE @KEY
        UNION ALL
        SELECT M.MEMBERID AS ID, M.FULLNAME, N'Member' AS TYPE, M.PHONE, M.JOINDATE, R.REGDATE, R.ENDDATE, ISNULL(R.TOTALAMOUNT, 0) AS TOTALAMOUNT, R.PAYMENTSTATUS, R.PACKAGEID, R.TRAINERID, M.STATUS, ISNULL(T.FULLNAME, N'Không có') AS GHICHU
        FROM MEMBERS M 
        LEFT JOIN (
        SELECT * FROM REGISTRATIONS
        WHERE REGID IN (
            SELECT MAX(REGID) 
            FROM REGISTRATIONS 
            GROUP BY MEMBERID
            )
        ) R ON M.MEMBERID = R.MEMBERID
        LEFT JOIN TRAINERS T ON R.TRAINERID = T.TRAINERID
        WHERE M.FULLNAME LIKE @KEY OR M.PHONE LIKE @KEY";

            DataTable dt = new DataTable();
            using (SqlConnection con = dc.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@key", "%" + keyword + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public bool DeleteRecord(int id, string targetRole)
        {
            string sql = "";
            // Dựa vào 'type targetRole' (cột TYPE trên Grid) để quyết định bảng và cột ID cần xóa
            switch (targetRole)
            {
                case "Admin":
                case "Manager":
                case "Receptionist":
                    // Xóa trong bảng USERS
                    sql = "DELETE FROM USERS WHERE USERID = @ID";
                    break;

                case "Member":
                    // Xóa trong bảng MEMBERS. 
                    // Nhờ ON DELETE CASCADE trong DB của bạn, REGISTRATIONS sẽ tự xóa theo.
                    sql = "DELETE FROM MEMBERS WHERE MEMBERID = @ID";
                    break;

                default:
                    // Giả định các trường hợp còn lại là Huấn luyện viên (Trainer)
                    sql = "DELETE FROM TRAINERS WHERE TRAINERID = @ID";
                    break;
            }

            try
            {
                using (SqlConnection con = dc.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Bạn có thể dùng MessageBox ở đây hoặc throw để BLL xử lý
                throw new Exception("Lỗi khi xóa dữ liệu: " + ex.Message);
            }
        }

        public bool SaveMember(MemberDTO dto, bool isAdd)
        {
            using (SqlConnection con = dc.GetConnection())
            {
                con.Open();
                SqlTransaction trans = con.BeginTransaction();
                try
                {
                    string sql = isAdd ?
                        @"INSERT INTO MEMBERS (FULLNAME, PHONE, JOINDATE, STATUS) 
                  VALUES (@name, @phone, GETDATE(), @memberStatus);
                  DECLARE @mID INT = SCOPE_IDENTITY();
                  INSERT INTO REGISTRATIONS 
                      (MEMBERID, PACKAGEID, TRAINERID, REGDATE, ENDDATE, TOTALAMOUNT, PAYMENTSTATUS)
                  VALUES (@mID, @pkg, @trn, @rd, @ed, @total, @status)" :

                        @"UPDATE MEMBERS 
                  SET FULLNAME=@name, PHONE=@phone, STATUS=@memberStatus
                  WHERE MEMBERID=@id;
                  UPDATE REGISTRATIONS 
                  SET PACKAGEID=@pkg, TRAINERID=@trn, REGDATE=@rd,
                      ENDDATE=@ed, TOTALAMOUNT=@total, PAYMENTSTATUS=@status
                  WHERE REGID = (
                      SELECT MAX(REGID) FROM REGISTRATIONS WHERE MEMBERID=@id
                  )";

                    SqlCommand cmd = new SqlCommand(sql, con, trans);
                    cmd.Parameters.AddWithValue("@id", dto.ID);
                    cmd.Parameters.AddWithValue("@name", dto.FullName);
                    cmd.Parameters.AddWithValue("@phone", dto.Phone);
                    cmd.Parameters.AddWithValue("@memberStatus", dto.Status ?? "Active"); // thêm
                    cmd.Parameters.AddWithValue("@pkg", dto.PackageID);
                    cmd.Parameters.AddWithValue("@trn", (object)dto.TrainerID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@rd", dto.RegDate);
                    cmd.Parameters.AddWithValue("@ed", dto.EndDate);
                    cmd.Parameters.AddWithValue("@total", dto.TotalAmount);
                    cmd.Parameters.AddWithValue("@status", dto.PaymentStatus);

                    cmd.ExecuteNonQuery();
                    trans.Commit();
                    return true;
                }
                catch { trans.Rollback(); return false; }
            }
        }

        public DataTable GetPackages()
        {
            return dc.ExecuteQuery("SELECT PACKAGEID, PACKAGENAME, DURATIONMONTHS, PRICE FROM PACKAGES");
        }

        public DataTable GetTrainers()
        {
            return dc.ExecuteQuery("SELECT TRAINERID, FULLNAME FROM TRAINERS");
        }

        // Kiểm tra trạng thái thanh toán của Member
        public string GetMemberStatus(int id)
        {
            using (SqlConnection con = dc.GetConnection())
            {
                string sql = @"SELECT TOP 1 PAYMENTSTATUS 
                       FROM REGISTRATIONS 
                       WHERE MEMBERID = @ID 
                       ORDER BY (CASE WHEN PAYMENTSTATUS = 'Paid' THEN 1 ELSE 2 END) ASC";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();

                object result = cmd.ExecuteScalar();
                return result?.ToString() ?? "No Registration";
            }
        }

        // Kiểm tra số lượng học viên của Trainer
        public int GetTrainerStudentCount(int id)
        {
            using (SqlConnection con = dc.GetConnection())
            {
                // Giả sử bảng REGISTRATIONS lưu mối quan hệ giữa học viên và HLV
                string sql = "SELECT COUNT(*) FROM REGISTRATIONS WHERE TRAINERID = @ID";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

    }
}
