using desktopapp_GYM.DTO;
using System;
using System.Collections;
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

        public DataTable GetTopPackages(int topCount)
        {
            string sql = $@"SELECT TOP {topCount} 
                        PACKAGENAME AS [Tên gói], 
                        COUNT(REGID) AS [Người dùng]
                    FROM PACKAGES p
                    LEFT JOIN REGISTRATIONS r ON p.PACKAGEID = r.PACKAGEID
                    GROUP BY PACKAGENAME
                    ORDER BY COUNT(REGID) DESC";

            using (SqlConnection con = GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public List<PackageDTO> GetPackagesByTrainer(int trainerId)
        {
            List<PackageDTO> list = new List<PackageDTO>();
            string query = @"
        SELECT p.PACKAGEID, p.PACKAGENAME 
        FROM PACKAGES p
        JOIN TRAINER_PACKAGES tp ON p.PACKAGEID = tp.PACKAGEID
        WHERE tp.TRAINERID = @TrainerID";
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TrainerID", trainerId);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new PackageDTO
                            {
                                PackageID = Convert.ToInt32(reader["PACKAGEID"]),
                                PackageName = reader["PACKAGENAME"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách gói tập của HLV: " + ex.Message);
            }

            return list;
        }

        public List<PackageDTO> GetByType(string type)
        {
            var list = new List<PackageDTO>();
            string sql = @"
        SELECT p.PACKAGEID, p.PACKAGENAME, p.TYPE, 
               p.DURATIONMONTHS, p.PRICE, p.PT_SESSIONS_PER_WEEK, p.STATUS,
               COUNT(DISTINCT r.REGID) AS TotalMembers
        FROM PACKAGES p
        LEFT JOIN REGISTRATIONS r ON p.PACKAGEID = r.PACKAGEID
        WHERE p.TYPE = @type AND p.STATUS = 'Active'
        GROUP BY p.PACKAGEID, p.PACKAGENAME, p.TYPE,
                 p.DURATIONMONTHS, p.PRICE, p.PT_SESSIONS_PER_WEEK, p.STATUS";

            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@type", type);
                con.Open();
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    list.Add(new PackageDTO
                    {
                        PackageID = Convert.ToInt32(r["PACKAGEID"]),
                        PackageName = r["PACKAGENAME"].ToString(),
                        Type = r["TYPE"].ToString(),
                        DurationMonths = Convert.ToInt32(r["DURATIONMONTHS"]),
                        Price = Convert.ToDecimal(r["PRICE"]),
                        PTSessionsPerWeek = r["PT_SESSIONS_PER_WEEK"] == DBNull.Value
                                                ? (int?)null
                                                : Convert.ToInt32(r["PT_SESSIONS_PER_WEEK"]),
                        Status = r["STATUS"].ToString(),
                        TotalMembers = Convert.ToInt32(r["TotalMembers"])
                    });
                }
            }
            return list;
        }

        public PackageDTO GetById(int packageId)
        {
            string sql = @"
        SELECT PACKAGEID, PACKAGENAME, TYPE, DURATIONMONTHS, 
               PRICE, PT_SESSIONS_PER_WEEK, STATUS
        FROM PACKAGES 
        WHERE PACKAGEID = @id";

            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", packageId);
                con.Open();
                SqlDataReader r = cmd.ExecuteReader();
                if (r.Read())
                {
                    return new PackageDTO
                    {
                        PackageID = Convert.ToInt32(r["PACKAGEID"]),
                        PackageName = r["PACKAGENAME"].ToString(),
                        Type = r["TYPE"].ToString(),
                        DurationMonths = Convert.ToInt32(r["DURATIONMONTHS"]),
                        Price = Convert.ToDecimal(r["PRICE"]),
                        PTSessionsPerWeek = r["PT_SESSIONS_PER_WEEK"] == DBNull.Value
                                                ? (int?)null
                                                : Convert.ToInt32(r["PT_SESSIONS_PER_WEEK"]),
                        Status = r["STATUS"].ToString()
                    };
                }
            }
            return null;
        }

    }
}
