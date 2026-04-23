using desktopapp_GYM.BLL;
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
        private ScheduleBLL _bll = new ScheduleBLL();
        public List<TimeslotDTO> GetAll()
        {
            var list = new List<TimeslotDTO>();
            string sql = @"
        SELECT 
            ts.SLOTID, ts.TRAINERID, ts.PACKAGEID,
            t.FULLNAME    AS TrainerName,
            p.PACKAGENAME AS PackageName,
            ts.SLOTNAME, ts.DAYOFWEEK,
            CONVERT(VARCHAR(5), ts.STARTTIME, 108) AS StartTime,
            CONVERT(VARCHAR(5), ts.ENDTIME,   108) AS EndTime,
            ts.MAXMEMBERS, ts.STATUS,
            COUNT(DISTINCT rs.REGID) AS CurrentCount
        FROM TIMESLOTS ts
        JOIN TRAINERS  t  ON ts.TRAINERID = t.TRAINERID
        JOIN PACKAGES  p  ON ts.PACKAGEID = p.PACKAGEID
        LEFT JOIN REGISTRATION_SLOTS rs ON ts.SLOTID = rs.SLOTID
        LEFT JOIN REGISTRATIONS r ON rs.REGID = r.REGID 
                                  AND r.IS_ACTIVE = 1
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
                        StartTime = r["StartTime"].ToString(),  
                        EndTime = r["EndTime"].ToString(),    
                        MaxMembers = Convert.ToInt32(r["MAXMEMBERS"]),
                        CurrentCount = Convert.ToInt32(r["CurrentCount"]),
                        Status = r["STATUS"].ToString()
                    });
                }
            }
            return list;
        }

        public List<TimeslotDTO> GetByTrainerPackageDay(int trainerId, int packageId, string dayOfWeek)
        {
            var list = new List<TimeslotDTO>();
            string sql = @"
        SELECT ts.SLOTID, ts.SLOTNAME, ts.DAYOFWEEK,
               CONVERT(VARCHAR(5), ts.STARTTIME, 108) AS StartTime,
               CONVERT(VARCHAR(5), ts.ENDTIME,   108) AS EndTime,
               ts.MAXMEMBERS, ts.STATUS,
               t.FULLNAME AS TrainerName,
               -- Đếm số member đã đăng ký slot này (đang active)
               COUNT(DISTINCT rs.REGID) AS CurrentCount
        FROM TIMESLOTS ts
        JOIN TRAINERS t ON ts.TRAINERID = t.TRAINERID
        LEFT JOIN REGISTRATION_SLOTS rs ON ts.SLOTID = rs.SLOTID
        LEFT JOIN REGISTRATIONS r ON rs.REGID = r.REGID AND r.IS_ACTIVE = 1
        WHERE ts.TRAINERID = @tid
          AND ts.PACKAGEID = @pid
          AND ts.DAYOFWEEK = @day
          AND ts.STATUS    = 'Active'
        GROUP BY ts.SLOTID, ts.SLOTNAME, ts.DAYOFWEEK,
                 ts.STARTTIME, ts.ENDTIME, ts.MAXMEMBERS, ts.STATUS,
                 t.FULLNAME
        HAVING COUNT(DISTINCT rs.REGID) < ts.MAXMEMBERS";

            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@tid", trainerId);
                cmd.Parameters.AddWithValue("@pid", packageId);
                cmd.Parameters.AddWithValue("@day", dayOfWeek);
                con.Open();
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    list.Add(new TimeslotDTO
                    {
                        SlotID = Convert.ToInt32(r["SLOTID"]),
                        SlotName = r["SLOTNAME"].ToString(),
                        DayOfWeek = r["DAYOFWEEK"].ToString(),
                        StartTime = r["StartTime"].ToString(),
                        EndTime = r["EndTime"].ToString(),
                        MaxMembers = Convert.ToInt32(r["MAXMEMBERS"]),
                        Status = r["STATUS"].ToString(),
                        TrainerName = r["TrainerName"].ToString(),
                        CurrentCount = Convert.ToInt32(r["CurrentCount"])
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

            using (SqlConnection con = GetConnection()) 
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MemberID", memberId);

                con.Open();
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

        public List<string> GetDaysByTrainerPackage(int trainerId, int packageId)
        {
            var list = new List<string>();
            string sql = @"
    SELECT DAYOFWEEK FROM (
        SELECT DISTINCT DAYOFWEEK,
            CASE DAYOFWEEK
                WHEN N'Thứ 2'    THEN 1
                WHEN N'Thứ 3'    THEN 2
                WHEN N'Thứ 4'    THEN 3
                WHEN N'Thứ 5'    THEN 4
                WHEN N'Thứ 6'    THEN 5
                WHEN N'Thứ 7'    THEN 6
                WHEN N'Chủ Nhật' THEN 7
                ELSE 8
            END AS SortOrder
        FROM TIMESLOTS ts
        LEFT JOIN REGISTRATION_SLOTS rs ON ts.SLOTID = rs.SLOTID
        LEFT JOIN REGISTRATIONS r ON rs.REGID = r.REGID AND r.IS_ACTIVE = 1
        WHERE ts.TRAINERID = @tid
          AND ts.PACKAGEID = @pid
          AND ts.STATUS    = 'Active'
        GROUP BY ts.DAYOFWEEK, ts.SLOTID, ts.MAXMEMBERS -- Nhóm theo slot để đếm sĩ số từng ca
        HAVING COUNT(DISTINCT rs.REGID) < ts.MAXMEMBERS -- Chỉ lấy các ca còn chỗ
    ) sub
    GROUP BY DAYOFWEEK, SortOrder
    ORDER BY SortOrder";

            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@tid", trainerId);
                cmd.Parameters.AddWithValue("@pid", packageId);
                con.Open();
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                    list.Add(r["DAYOFWEEK"].ToString());
            }
            return list;
        }

        public int GetCurrentCount(int slotId)
        {
            string sql = @"
        SELECT COUNT(DISTINCT rs.REGID) 
        FROM REGISTRATION_SLOTS rs
        JOIN REGISTRATIONS r ON rs.REGID = r.REGID
        WHERE rs.SLOTID = @sid AND r.IS_ACTIVE = 1";

            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@sid", slotId);
                con.Open();
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }

        public bool IsSlotFull(int slotId, int maxMembers)
        {
            return GetCurrentCount(slotId) >= maxMembers;
        }

        public bool SyncCurrentCount(int slotId)
        {
            // Câu lệnh SQL này sử dụng Subquery để đếm số lượng bản ghi active 
            // từ bảng REGISTRATION_SLOTS và cập nhật trực tiếp vào TIMESLOTS
            string sql = @"
        UPDATE TIMESLOTS 
        SET CurrentCount = (
            SELECT COUNT(DISTINCT rs.REGID) 
            FROM REGISTRATION_SLOTS rs
            JOIN REGISTRATIONS r ON rs.REGID = r.REGID
            WHERE rs.SLOTID = @sid AND r.IS_ACTIVE = 1
        )
        WHERE SLOTID = @sid";

            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@sid", slotId);
                try
                {
                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Lỗi đồng bộ sĩ số: " + ex.Message);
                    return false;
                }
            }
        }

        public bool SyncAllAttendance()
        {
            // Câu lệnh này sẽ:
            // 1. Đếm số lượng đăng ký thực tế trong bảng trung gian (giả sử tên là RegistrationSlots hoặc RegistrationDetails)
            // 2. Cập nhật con số đó vào cột CurrentCount của bảng Timeslots
            // 3. Chỉ đếm các đăng ký mà hợp đồng vẫn còn hiệu lực (IsActive = 1)

            string sql = @"
        UPDATE Timeslots
        SET CurrentCount = (
            SELECT COUNT(*)
            FROM REGISTRATION_SLOTS rs
            JOIN REGISTRATIONS r ON rs.RegID = r.RegID
            WHERE rs.SlotID = Timeslots.SlotID
              AND r.IS_ACTIVE = 1
        )";

            try
            {
                return ExecuteNonQuery(sql) >= 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi đồng bộ sĩ số tổng: " + ex.Message);
            }
        }

        public DataTable GetTimeslotsToday()
        {
            DayOfWeek dotw = DateTime.Now.DayOfWeek;
            string today = _bll.GetVietnameseDayOfWeek(dotw);

            string sql = @"SELECT SlotName, 
                          StartTime, 
                          (CAST(CurrentCount AS NVARCHAR) + '/' + CAST(MaxMembers AS NVARCHAR)) as Attendance
                   FROM TIMESLOTS 
                   WHERE DayOfWeek = @Today AND Status = 'Active'
                   ORDER BY StartTime ASC";

            SqlParameter[] parameters = { new SqlParameter("@Today", today) };
            return ExecuteQuery(sql, parameters);
        }

    }

}

