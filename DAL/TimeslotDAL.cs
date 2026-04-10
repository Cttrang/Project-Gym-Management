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
    public class TimeslotDAL : DataConnection
    {
        public List<TimeslotDTO> GetAll()
        {
            var list = new List<TimeslotDTO>();
            string sql = @"
                SELECT 
                    ts.SLOTID, ts.TRAINERID, ts.PACKAGEID,
                    t.FULLNAME    AS TrainerName,
                    p.PACKAGENAME AS PackageName,
                    ts.SLOTNAME, ts.DAYOFWEEK,
                    ts.STARTTIME, ts.ENDTIME,
                    ts.MAXMEMBERS, ts.STATUS,
                    COUNT(s.SCHEDULEID) AS CurrentCount
                FROM TIMESLOTS ts
                JOIN TRAINERS  t ON ts.TRAINERID = t.TRAINERID
                JOIN PACKAGES  p ON ts.PACKAGEID = p.PACKAGEID
                LEFT JOIN SCHEDULES s ON ts.SLOTID = s.SLOTID 
                                      AND s.STATUS != 'Cancelled'
                GROUP BY 
                    ts.SLOTID, ts.TRAINERID, ts.PACKAGEID,
                    t.FULLNAME, p.PACKAGENAME,
                    ts.SLOTNAME, ts.DAYOFWEEK,
                    ts.STARTTIME, ts.ENDTIME,
                    ts.MAXMEMBERS, ts.STATUS
                ORDER BY ts.DAYOFWEEK, ts.STARTTIME";

            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    list.Add(new TimeslotDTO
                    {
                        SlotID = Convert.ToInt32(r["SLOTID"]),
                        TrainerID = Convert.ToInt32(r["TRAINERID"]),
                        PackageID = Convert.ToInt32(r["PACKAGEID"]),
                        TrainerName = r["TrainerName"].ToString(),
                        PackageName = r["PackageName"].ToString(),
                        SlotName = r["SLOTNAME"].ToString(),
                        DayOfWeek = r["DAYOFWEEK"].ToString(),
                        StartTime = r["STARTTIME"].ToString(),
                        EndTime = r["ENDTIME"].ToString(),
                        MaxMembers = Convert.ToInt32(r["MAXMEMBERS"]),
                        CurrentCount = Convert.ToInt32(r["CurrentCount"]),
                        Status = r["STATUS"].ToString()
                    });
                }
            }
            return list;
        }

        public bool Save(TimeslotDTO ts, bool isAdd)
        {
            string sql = isAdd ?
                @"INSERT INTO TIMESLOTS 
                    (TRAINERID, PACKAGEID, SLOTNAME, DAYOFWEEK, STARTTIME, ENDTIME, MAXMEMBERS, STATUS)
                  VALUES 
                    (@tid, @pid, @name, @day, @start, @end, @max, @status)" :
                @"UPDATE TIMESLOTS SET
                    TRAINERID=@tid, PACKAGEID=@pid, SLOTNAME=@name,
                    DAYOFWEEK=@day, STARTTIME=@start, ENDTIME=@end,
                    MAXMEMBERS=@max, STATUS=@status
                  WHERE SLOTID=@id";

            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                if (!isAdd) cmd.Parameters.AddWithValue("@id", ts.SlotID);

                cmd.Parameters.AddWithValue("@tid", ts.TrainerID);
                cmd.Parameters.AddWithValue("@pid", ts.PackageID);
                cmd.Parameters.AddWithValue("@name", ts.SlotName);
                cmd.Parameters.AddWithValue("@day", ts.DayOfWeek);
                cmd.Parameters.AddWithValue("@start", ts.StartTime);
                cmd.Parameters.AddWithValue("@end", ts.EndTime);
                cmd.Parameters.AddWithValue("@max", ts.MaxMembers);
                cmd.Parameters.AddWithValue("@status", ts.Status ?? "Active");
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

        public bool Delete(int slotId)
        {
            string sql = "DELETE FROM TIMESLOTS WHERE SLOTID = @id";
            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", slotId);
                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Lấy danh sách HLV cho dropdown — lọc theo gói đã chọn
        public DataTable GetTrainersByPackage(int packageId)
        {
            string sql = @"
                SELECT t.TRAINERID, t.FULLNAME
                FROM TRAINERS t
                JOIN TRAINER_PACKAGES tp ON t.TRAINERID = tp.TRAINERID
                WHERE tp.PACKAGEID = @pid AND t.STATUS = 'Active'";
            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@pid", packageId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public List<int> GetSlotIdsByMember(int memberId)
        {
            List<int> list = new List<int>();
            string sql = @"SELECT rs.SLOTID 
                   FROM REGISTRATION_SLOTS rs
                   JOIN REGISTRATIONS r ON rs.REGID = r.REGID
                   WHERE r.MEMBERID = @MemberID";

            using (SqlConnection con = GetConnection()) // Sử dụng GetConnection() giống hàm trên
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MemberID", memberId);

                con.Open(); // Mở kết nối trước khi thực thi
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        list.Add(Convert.ToInt32(dr["SLOTID"]));
                    }
                }
            }
            return list;
        }

    }

}

