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
            0 AS TOTALAMOUNT, '' AS PAYMENTSTATUS, NULL AS PACKAGEID, NULL AS TRAINERID,
            T.STATUS, T.SPECIALTY AS GHICHU
        FROM TRAINERS T

        UNION ALL

        -- 3. MEMBERS (Thêm Package và Trainer ID từ bảng Registrations)
        SELECT 
    M.MEMBERID AS ID, M.FULLNAME, N'Member' AS TYPE, M.PHONE, 
    M.JOINDATE, R.REGDATE, R.ENDDATE, 
    ISNULL(R.TOTALAMOUNT, 0) AS TOTALAMOUNT, R.PAYMENTSTATUS,
    R.PACKAGEID, R.TRAINERID, M.STATUS, ISNULL(T.FULLNAME, N'Không có') AS GHICHU
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
        SELECT T.TRAINERID AS ID, T.FULLNAME, N'Trainer' AS TYPE, T.PHONE, NULL AS JOINDATE, NULL AS REGDATE, NULL AS ENDDATE, 0 AS TOTALAMOUNT, '' AS PAYMENTSTATUS, NULL AS PACKAGEID, NULL AS TRAINERID, T.STATUS, T.SPECIALTY AS GHICHU
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
        public bool DeleteRecord(int id, string type)
        {
            string sql = "";
            // Dựa vào 'type' (cột TYPE trên Grid) để quyết định bảng và cột ID cần xóa
            switch (type)
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
                        @"INSERT INTO MEMBERS (FULLNAME, PHONE, JOINDATE) VALUES (@name, @phone, GETDATE());
                  DECLARE @mID INT = SCOPE_IDENTITY();
                  INSERT INTO REGISTRATIONS (MEMBERID, PACKAGEID, TRAINERID, REGDATE, ENDDATE, TOTALAMOUNT, PAYMENTSTATUS)
                  VALUES (@mID, @pkg, @trn, @rd, @ed, @total, @status)" :
                        @"UPDATE MEMBERS SET FULLNAME=@name, PHONE=@phone WHERE MEMBERID=@id;
                  UPDATE REGISTRATIONS SET PACKAGEID=@pkg, TRAINERID=@trn, REGDATE=@rd, ENDDATE=@ed, 
                  TOTALAMOUNT=@total, PAYMENTSTATUS=@status WHERE MEMBERID=@id";

                    SqlCommand cmd = new SqlCommand(sql, con, trans);
                    cmd.Parameters.AddWithValue("@id", dto.ID);
                    cmd.Parameters.AddWithValue("@name", dto.FullName);
                    cmd.Parameters.AddWithValue("@phone", dto.Phone);
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



    }
}
