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
            string query = @"SELECT p.PACKAGEID, p.PACKAGENAME, p.DURATIONMONTHS, p.PRICE, p.STATUS, 
                             COUNT(r.REGID) AS TotalMembers 
                             FROM PACKAGES p 
                             LEFT JOIN REGISTRATIONS r ON p.PACKAGEID = r.PACKAGEID 
                             GROUP BY p.PACKAGEID, p.PACKAGENAME, p.DURATIONMONTHS, p.PRICE, p.STATUS";

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        PackageDTO pkg = new PackageDTO();
                        pkg.PackageID = Convert.ToInt32(reader["PACKAGEID"]);
                        pkg.PackageName = reader["PACKAGENAME"].ToString();
                        pkg.DurationMonths = Convert.ToInt32(reader["DURATIONMONTHS"]);
                        pkg.Price = Convert.ToDecimal(reader["PRICE"]);
                        pkg.Status = reader["status"].ToString();
                        pkg.TotalMembers = Convert.ToInt32(reader["TotalMembers"]);

                        list.Add(pkg);
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
        "INSERT INTO PACKAGES (PACKAGENAME, DURATIONMONTHS, PRICE, STATUS) VALUES (@name, @dur, @pri, @status)" :
        "UPDATE PACKAGES SET PACKAGENAME=@name, DURATIONMONTHS=@dur, PRICE=@pri, STATUS=@status WHERE PACKAGEID=@id";

            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", pkg.PackageID);
                cmd.Parameters.AddWithValue("@name", pkg.PackageName);
                cmd.Parameters.AddWithValue("@dur", pkg.DurationMonths);
                cmd.Parameters.AddWithValue("@pri", pkg.Price);
                cmd.Parameters.AddWithValue("@status", pkg.Status ?? "Active"); // thêm dòng này
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
