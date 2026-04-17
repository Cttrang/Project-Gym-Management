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
            // Câu truy vấn mới: Lấy thông tin HLV + Gộp tên các gói tập thành 1 chuỗi
            string query = @"
        SELECT t.TRAINERID, t.FULLNAME, t.PHONE, t.SPECIALTY, t.STATUS,
               COUNT(DISTINCT r.REGID) AS TotalStudents,
               STUFF((
                   SELECT ', ' + p.PACKAGENAME
                   FROM TRAINER_PACKAGES tp
                   JOIN PACKAGES p ON tp.PACKAGEID = p.PACKAGEID
                   WHERE tp.TRAINERID = t.TRAINERID
                   FOR XML PATH('')), 1, 2, '') AS Packages
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
                            TotalStudents = Convert.ToInt32(reader["TotalStudents"]),
                            // Gán chuỗi các gói tập vào thuộc tính mới
                            AssignedPackages = reader["Packages"].ToString()
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

        // Thêm hàm này vào TrainerDAL để lấy ID vừa tạo nếu dùng chức năng add new Trainer
        public int SaveAndGetID(TrainerDTO tr)
        {
            string sql = "INSERT INTO TRAINERS (FULLNAME, PHONE, SPECIALTY, STATUS) OUTPUT INSERTED.TRAINERID VALUES (@name, @phone, @spec, @status)";
            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@name", tr.FullName);
                cmd.Parameters.AddWithValue("@phone", tr.Phone ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@spec", tr.Specialty ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@status", tr.Status);
                con.Open();
                return (int)cmd.ExecuteScalar(); // Trả về ID vừa tạo
            }
        }

        // Hàm lưu chuyên môn vào bảng trung gian
        public bool SaveWithPackages(TrainerDTO tr, List<int> packageIds, bool isAdd)
        {
            using (SqlConnection con = GetConnection())
            {
                con.Open();
                SqlTransaction trans = con.BeginTransaction();
                try
                {
                    int trainerId;

                    if (isAdd)
                    {
                        // INSERT và lấy ID vừa tạo
                        string insertSql = @"INSERT INTO TRAINERS 
                    (FULLNAME, PHONE, SPECIALTY, STATUS) 
                    OUTPUT INSERTED.TRAINERID 
                    VALUES (@name, @phone, @spec, @status)";
                        SqlCommand insertCmd = new SqlCommand(insertSql, con, trans);
                        insertCmd.Parameters.AddWithValue("@name", tr.FullName);
                        insertCmd.Parameters.AddWithValue("@phone", tr.Phone ?? (object)DBNull.Value);
                        insertCmd.Parameters.AddWithValue("@spec", tr.Specialty ?? (object)DBNull.Value);
                        insertCmd.Parameters.AddWithValue("@status", tr.Status ?? "Active");
                        trainerId = (int)insertCmd.ExecuteScalar();
                    }
                    else
                    {
                        // UPDATE thông tin HLV
                        string updateSql = @"UPDATE TRAINERS 
                    SET FULLNAME=@name, PHONE=@phone, SPECIALTY=@spec, STATUS=@status 
                    WHERE TRAINERID=@id";
                        SqlCommand updateCmd = new SqlCommand(updateSql, con, trans);
                        updateCmd.Parameters.AddWithValue("@id", tr.TrainerID);
                        updateCmd.Parameters.AddWithValue("@name", tr.FullName);
                        updateCmd.Parameters.AddWithValue("@phone", tr.Phone ?? (object)DBNull.Value);
                        updateCmd.Parameters.AddWithValue("@spec", tr.Specialty ?? (object)DBNull.Value);
                        updateCmd.Parameters.AddWithValue("@status", tr.Status ?? "Active");
                        updateCmd.ExecuteNonQuery();
                        trainerId = tr.TrainerID;
                    }

                    // Xóa gói cũ rồi insert lại toàn bộ
                    string deleteSql = "DELETE FROM TRAINER_PACKAGES WHERE TRAINERID = @tid";
                    SqlCommand deleteCmd = new SqlCommand(deleteSql, con, trans);
                    deleteCmd.Parameters.AddWithValue("@tid", trainerId);
                    deleteCmd.ExecuteNonQuery();

                    // Insert các gói mới được chọn
                    foreach (int pkgId in packageIds)
                    {
                        string insertPkgSql = @"INSERT INTO TRAINER_PACKAGES 
                    (TRAINERID, PACKAGEID) VALUES (@tid, @pid)";
                        SqlCommand insertPkgCmd = new SqlCommand(insertPkgSql, con, trans);
                        insertPkgCmd.Parameters.AddWithValue("@tid", trainerId);
                        insertPkgCmd.Parameters.AddWithValue("@pid", pkgId);
                        insertPkgCmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Lỗi lưu dữ liệu: " + ex.Message);
                    return false;
                }
            }
        }

        public List<int> GetPackageIdsByTrainer(int trainerId)
        {
            List<int> ids = new List<int>();
            string sql = "SELECT PACKAGEID FROM TRAINER_PACKAGES WHERE TRAINERID = @id";
            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", trainerId);
                con.Open();
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read()) ids.Add((int)r["PACKAGEID"]);
            }
            return ids;
        }

        public DataTable GetTrainersForCombobox()
        {
            // Chỉ lấy ID và Tên của những Trainer đang làm việc để lọc
            string sql = "SELECT TRAINERID, FULLNAME FROM TRAINERS WHERE STATUS = 'Active' ORDER BY FULLNAME ASC";
            using (SqlConnection con = GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

    }
}
