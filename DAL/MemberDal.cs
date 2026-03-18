using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            string sql = @"SELECT TOP 5 m.FullName, r.EndDate 
                   FROM MEMBERS m 
                   JOIN REGISTRATIONS r ON m.MemberID = r.MemberID 
                   WHERE r.EndDate >= CAST(GETDATE() AS DATE) 
                     AND r.EndDate <= DATEADD(day, 7, GETDATE())
                   ORDER BY r.EndDate ASC";

            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = dc.GetConnection())
                {
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                // Debug nếu có lỗi kết nối
                Console.WriteLine("Lỗi SQL: " + ex.Message);
            }

            return dt;
        }


    }
}
