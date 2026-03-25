using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopapp_GYM.DAL
{
        public class DataConnection
        {
            // Chuỗi kết nối: Bạn cần thay "TEN-MAY-TINH" bằng tên Server của bạn
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GYMMANAGEMENT;Integrated Security=True";

            public SqlConnection GetConnection()
            {
                return new SqlConnection(connString);
            }

        public DataTable ExecuteQuery(string sql)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = GetConnection()) // Hàm GetConnection bạn đã có
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dt);
            }
            return dt;
        }
    }
    

}
