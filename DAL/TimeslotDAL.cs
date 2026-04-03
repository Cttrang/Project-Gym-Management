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
                        SlotID = (int)r["SLOTID"],
                        TrainerID = (int)r["TRAINERID"],
                        PackageID = (int)r["PACKAGEID"],
                        TrainerName = r["TrainerName"].ToString(),
                        PackageName = r["PackageName"].ToString(),
                        SlotName = r["SLOTNAME"].ToString(),
                        DayOfWeek = r["DAYOFWEEK"].ToString(),
                        StartTime = r["STARTTIME"].ToString(),
                        EndTime = r["ENDTIME"].ToString(),
                        MaxMembers = (int)r["MAXMEMBERS"],
                        CurrentCount = (int)r["CurrentCount"],
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
                cmd.Parameters.AddWithValue("@id", ts.SlotID);
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


    }

}

