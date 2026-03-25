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
            NULL AS JOINDATE, NULL AS REGID, NULL AS REGDATE, NULL AS ENDDATE, 
            0 AS TOTALAMOUNT, '' AS PAYMENTSTATUS, NULL AS PACKAGEID, NULL AS TRAINERID
        FROM USERS U

        UNION ALL

        -- 2. TRAINERS
        SELECT 
            T.TRAINERID AS ID, T.FULLNAME, T.SPECIALTY AS TYPE, T.PHONE, 
            NULL AS JOINDATE, NULL AS REGID, NULL AS REGDATE, NULL AS ENDDATE, 
            0 AS TOTALAMOUNT, '' AS PAYMENTSTATUS, NULL AS PACKAGEID, NULL AS TRAINERID
        FROM TRAINERS T

        UNION ALL

        -- 3. MEMBERS (Thêm Package và Trainer ID từ bảng Registrations)
        SELECT 
            M.MEMBERID AS ID, M.FULLNAME, N'Member' AS TYPE, M.PHONE, 
            M.JOINDATE, R.REGID, R.REGDATE, R.ENDDATE, 
            ISNULL(R.TOTALAMOUNT, 0) AS TOTALAMOUNT, R.PAYMENTSTATUS,
            R.PACKAGEID, R.TRAINERID
        FROM MEMBERS M
        LEFT JOIN REGISTRATIONS R ON M.MEMBERID = R.MEMBERID";

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
        SELECT U.USERID AS ID, U.USERNAME AS FULLNAME, U.ROLE AS TYPE, '' AS PHONE, NULL AS JOINDATE, NULL AS REGID, NULL AS REGDATE, NULL AS ENDDATE, 0 AS TOTALAMOUNT, '' AS PAYMENTSTATUS, NULL AS PACKAGEID, NULL AS TRAINERID
        FROM USERS U WHERE U.USERNAME LIKE @KEY
        UNION ALL
        SELECT T.TRAINERID AS ID, T.FULLNAME, T.SPECIALTY AS TYPE, T.PHONE, NULL AS JOINDATE, NULL AS REGID, NULL AS REGDATE, NULL AS ENDDATE, 0 AS TOTALAMOUNT, '' AS PAYMENTSTATUS, NULL AS PACKAGEID, NULL AS TRAINERID
        FROM TRAINERS T WHERE T.FULLNAME LIKE @KEY OR T.PHONE LIKE @KEY
        UNION ALL
        SELECT M.MEMBERID AS ID, M.FULLNAME, N'Member' AS TYPE, M.PHONE, M.JOINDATE, R.REGID, R.REGDATE, R.ENDDATE, ISNULL(R.TOTALAMOUNT, 0) AS TOTALAMOUNT, R.PAYMENTSTATUS, R.PACKAGEID, R.TRAINERID
        FROM MEMBERS M LEFT JOIN REGISTRATIONS R ON M.MEMBERID = R.MEMBERID
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
    }
}
