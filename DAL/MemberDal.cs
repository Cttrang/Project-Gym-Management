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
            // Ép kiểu số ngày thành chuỗi ngay trong SQL để C# không bị lỗi format
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


    }
}
