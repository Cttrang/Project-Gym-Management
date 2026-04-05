using desktopapp_GYM.DTO;
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
        public List<UserDTO> GetAll()
        {
            var list = new List<UserDTO>();
            string sql = "SELECT USERID, USERNAME, ROLE FROM USERS ORDER BY ROLE, USERNAME";
            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    list.Add(new UserDTO
                    {
                        UserID = (int)r["USERID"],
                        Username = r["USERNAME"].ToString(),
                        Role = r["ROLE"].ToString()
                        // Password không SELECT — bảo mật
                    });
                }
            }
            return list;
        }

        public bool Save(UserDTO user, bool isAdd)
        {
            string sql = isAdd ?
                @"INSERT INTO USERS (USERNAME, PASSWORD, ROLE)
                  VALUES (@username, @password, @role)" :
                @"UPDATE USERS SET USERNAME=@username, ROLE=@role
                  WHERE USERID=@id";
            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", user.UserID);
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@password", user.Password ?? "123456");
                cmd.Parameters.AddWithValue("@role", user.Role);
                try
                {
                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Lỗi: " + ex.Message);
                    return false;
                }
            }
        }

        public bool Delete(int id)
        {
            string sql = "DELETE FROM USERS WHERE USERID = @id";
            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool ResetPassword(int id, string newPassword)
        {
            string sql = "UPDATE USERS SET PASSWORD=@pwd WHERE USERID=@id";
            using (SqlConnection con = GetConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@newPass", newPassword); // Nhớ Hash nếu có dùng mã hóa
                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi Admin reset mật khẩu: " + ex.Message);
                }
            }
        }

        public bool VerifyOldPassword(string username, string oldPassword)
        {
            // Chỉ đếm số dòng khớp, không lấy dữ liệu password ra ngoài bộ nhớ C#
            string sql = "SELECT COUNT(*) FROM USERS WHERE USERNAME = @user AND PASSWORD = @pass";

            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", oldPassword); // Lưu ý: Nếu có Hash mật khẩu thì phải Hash trước khi đưa vào đây

                con.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0; // Nếu tìm thấy 1 dòng khớp thì trả về true
            }
        }

    }
}
