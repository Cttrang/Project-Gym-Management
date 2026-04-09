using desktopapp_GYM.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopapp_GYM.DAL
{
    public class PackageDAL : DataConnection
    {
        public List<PackageDTO> GetAllPackages()
        {
            List<PackageDTO> list = new List<PackageDTO>();

            // Câu SQL lấy thông tin gói tập và đếm số người đăng ký
            string query = @"
            SELECT p.*, 
                   (SELECT COUNT(*) FROM REGISTRATIONS r WHERE r.PACKAGEID = p.PACKAGEID) as TotalMembers
            FROM PACKAGES p";

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(new PackageDTO
                        {
                            PackageID = Convert.ToInt32(reader["PACKAGEID"]),
                            PackageName = reader["PACKAGENAME"].ToString(),
                            Type = reader["TYPE"].ToString(),
                            DurationMonths = Convert.ToInt32(reader["DURATIONMONTHS"]),
                            Price = Convert.ToDecimal(reader["PRICE"]),
                            // Xử lý giá trị Null cho số buổi
                            PTSessionsPerWeek = reader["PT_SESSIONS_PER_WEEK"] == DBNull.Value ?
                                         (int?)null : Convert.ToInt32(reader["PT_SESSIONS_PER_WEEK"]),
                            Status = reader["STATUS"].ToString(),
                            TotalMembers = Convert.ToInt32(reader["TotalMembers"])
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu cần
                throw ex;
            }
            return list;

        }
        public bool Save(PackageDTO pkg, bool isAdd)
        {
            string sql = isAdd ?
            @"INSERT INTO PACKAGES (PACKAGENAME, TYPE, DURATIONMONTHS, PRICE, PT_SESSIONS_PER_WEEK, STATUS) 
              VALUES (@name, @type, @dur, @price, @ptSessions, @status)" :
            @"UPDATE PACKAGES SET PACKAGENAME=@name, TYPE=@type, DURATIONMONTHS=@dur, 
              PRICE=@price, PT_SESSIONS_PER_WEEK=@ptSessions, STATUS=@status 
              WHERE PACKAGEID=@id";

            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                if (!isAdd) cmd.Parameters.AddWithValue("@id", pkg.PackageID);

                cmd.Parameters.AddWithValue("@name", pkg.PackageName);
                cmd.Parameters.AddWithValue("@type", pkg.Type);
                cmd.Parameters.AddWithValue("@dur", pkg.DurationMonths);
                cmd.Parameters.AddWithValue("@price", pkg.Price);
                // Nếu là gói FREE thì lưu DBNull
                cmd.Parameters.AddWithValue("@ptSessions", (object)pkg.PTSessionsPerWeek ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@status", pkg.Status ?? "Active");

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int id)
        {
            string sql = "DELETE FROM PACKAGES WHERE PACKAGEID = @id";
            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Trong file PackageDAL.cs
        public DataTable GetTopPackages(int topCount)
        {
            // Câu lệnh SQL: Đếm số người dùng, sắp xếp giảm dần và lấy Top
            string sql = $@"SELECT TOP {topCount} 
                        PACKAGENAME AS [Tên gói], 
                        COUNT(REGID) AS [Người dùng]
                    FROM PACKAGES p
                    LEFT JOIN REGISTRATIONS r ON p.PACKAGEID = r.PACKAGEID
                    GROUP BY PACKAGENAME
                    ORDER BY COUNT(REGID) DESC";

            using (SqlConnection con = GetConnection()) // Dùng kết nối tĩnh của Huy
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt; // Trả về DataTable chứa Tên gói và Số người
            }
        }

    }
}
