using desktopapp_GYM.DTO;
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
    public class TrainerDAL : DataConnection
    {
        public List<TrainerDTO> GetAllTrainers()
        {
            List<TrainerDTO> list = new List<TrainerDTO>();
            string query = @"SELECT t.TRAINERID, t.FULLNAME, t.PHONE, t.SPECIALTY, t.STATUS,
                             COUNT(r.REGID) AS TotalStudents
                             FROM TRAINERS t
                             LEFT JOIN REGISTRATIONS r ON t.TRAINERID = r.TRAINERID
                             GROUP BY t.TRAINERID, t.FULLNAME, t.PHONE, t.SPECIALTY, t.STATUS";

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new TrainerDTO
                        {
                            TrainerID = Convert.ToInt32(reader["TRAINERID"]),
                            FullName = reader["FULLNAME"].ToString(),
                            Phone = reader["PHONE"].ToString(),
                            Specialty = reader["SPECIALTY"].ToString(),
                            Status = reader["STATUS"].ToString(),
                            TotalStudents = Convert.ToInt32(reader["TotalStudents"])
                        });
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            return list;
        }
        public DataTable GetTopTrainers(int topCount)
        {
            // Thống kê HLV dựa trên số lượng hội viên đang theo tập (bảng REGISTRATIONS)
            string sql = $@"SELECT TOP {topCount} 
                        t.FULLNAME, 
                        t.SPECIALTY,
                        COUNT(r.REGID) AS MemberCount 
                    FROM TRAINERS t
                    LEFT JOIN REGISTRATIONS r ON t.TRAINERID = r.TRAINERID
                    WHERE t.STATUS = 'Active'
                    GROUP BY t.FULLNAME, t.SPECIALTY
                    ORDER BY MemberCount DESC";
            using (SqlConnection con = GetConnection()) // Dùng kết nối tĩnh của Huy
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt; // Trả về DataTable chứa Tên gói và Số người
            }
        }

        public bool Save(TrainerDTO tr, bool isAdd)
        {
            string sql = isAdd ?
                "INSERT INTO TRAINERS (FULLNAME, PHONE, SPECIALTY, STATUS) VALUES (@name, @phone, @spec, @status)" :
                "UPDATE TRAINERS SET FULLNAME=@name, PHONE=@phone, SPECIALTY=@spec, STATUS=@status WHERE TRAINERID=@id";

            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                if (!isAdd)
                {
                    cmd.Parameters.AddWithValue("@id", tr.TrainerID);
                }
                //cmd.Parameters.AddWithValue("@id", tr.TrainerID);
                cmd.Parameters.AddWithValue("@name", tr.FullName);
                cmd.Parameters.AddWithValue("@phone", tr.Phone ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@spec", tr.Specialty ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@status", tr.Status ?? "Active");
                //con.Open();
                //return cmd.ExecuteNonQuery() > 0;
                try
                {
                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString()); // 🔥 lỗi thật sẽ hiện ở đây
                    return false;
                }
            }
        }

        public bool Delete(int id)
        {
            string sql = "DELETE FROM TRAINERS WHERE TRAINERID = @id";
            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
