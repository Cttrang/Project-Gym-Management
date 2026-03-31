using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopapp_GYM.DAL
{
    public class RegistrationDAL
    {
        DataConnection dc = new DataConnection();
        public decimal GetMonthlyRevenue()
        {
            // ISNULL giúp tránh lỗi nếu tháng đó chưa có doanh thu
            string sql = "SELECT ISNULL(SUM(TOTALAMOUNT), 0) FROM REGISTRATIONS WHERE MONTH(REGDATE) = MONTH(GETDATE()) AND YEAR(REGDATE) = YEAR(GETDATE())";
            using (SqlConnection con = dc.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                return Convert.ToDecimal(cmd.ExecuteScalar());
            }
        }
        public DataTable GetRevenueData()
        {
            // Lấy doanh thu của 6 tháng gần nhất
            string sql = @"SELECT FORMAT(REGDATE, 'MM/yyyy') AS MonthYear, SUM(TOTALAMOUNT) AS Total 
                   FROM REGISTRATIONS 
                   GROUP BY FORMAT(REGDATE, 'MM/yyyy'), YEAR(REGDATE), MONTH(REGDATE)
                   ORDER BY YEAR(REGDATE) DESC, MONTH(REGDATE) DESC";

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
