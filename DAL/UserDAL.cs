using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopapp_GYM.DAL
{
    public class UserDAL : DataConnection
    {
        public string CheckLogin(string user, string pass)
        {
            string role = null;
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string sql = "SELECT ROLE FROM USERS WHERE USERNAME=@user AND PASSWORD=@pass";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@pass", pass);

                object result = cmd.ExecuteScalar(); // Lấy duy nhất 1 giá trị (cột Role)
                if (result != null) role = result.ToString();
            }
            return role;
        }
    }
}
