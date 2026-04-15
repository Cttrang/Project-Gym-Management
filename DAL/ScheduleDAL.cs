using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopapp_GYM.DAL
{
    public class ScheduleDAL : DataConnection
    {
        public List<ScheduleViewDTO> GetSchedules(DateTime date, int? trainerId = null, string status = null, int? memberId = null, int? slotId = null)
        {
            List<ScheduleViewDTO> list = new List<ScheduleViewDTO>();

            string sql = @"
        SELECT 
            S.SCHEDULEID, S.TRAININGDATE, S.STATUS, S.NOTES, S.IS_MAKEUP, S.ORIGINAL_DATE,
            M.MEMBERID, M.FULLNAME AS MemberName,
            TS.SLOTID, TS.SLOTNAME, TS.STARTTIME,
            T.FULLNAME AS TrainerName,
            P.PACKAGENAME,
            R.REGID
        FROM SCHEDULES S
        JOIN REGISTRATIONS R ON S.REGID = R.REGID
        JOIN MEMBERS M ON R.MEMBERID = M.MEMBERID
        JOIN PACKAGES P ON R.PACKAGEID = P.PACKAGEID
        LEFT JOIN TIMESLOTS TS ON S.SLOTID = TS.SLOTID
        -- Lấy tên Trainer từ bảng TRAINERS dựa trên TRAINERID của REGISTRATIONS
        LEFT JOIN TRAINERS T ON R.TRAINERID = T.TRAINERID 
        WHERE S.TRAININGDATE = @Date";

            // Logic cộng chuỗi SQL giữ nguyên nhưng nhớ check slotId
            if (trainerId.HasValue && trainerId > 0) sql += " AND R.TRAINERID = @TrainerID";
            if (slotId.HasValue && slotId > 0) sql += " AND S.SLOTID = @SlotID"; // <--- Đã có trong code của bạn
            if (!string.IsNullOrEmpty(status) && status != "--- Tất cả ---") sql += " AND S.STATUS = @Status";
            if (memberId.HasValue) sql += " AND M.MEMBERID = @MemberID";

            sql += " ORDER BY TS.STARTTIME ASC";

            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@Date", date.Date),
                    new SqlParameter("@TrainerID", (object)trainerId ?? DBNull.Value),
                    new SqlParameter("@SlotID", (object)slotId ?? DBNull.Value),
                    new SqlParameter("@Status", (object)status ?? DBNull.Value),
                    new SqlParameter("@MemberID", (object)memberId ?? DBNull.Value)
                };

                DataTable dt = ExecuteQuery(sql, parameters); // Hàm thực thi query trả về DataTable
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ScheduleViewDTO
                    {
                        ScheduleID = Convert.ToInt32(dr["SCHEDULEID"]),
                        TrainingDate = Convert.ToDateTime(dr["TRAININGDATE"]),
                        Status = dr["STATUS"].ToString(),
                        Notes = dr["NOTES"].ToString(),
                        IsMakeup = Convert.ToBoolean(dr["IS_MAKEUP"]),
                        MemberID_Display = dr["MEMBERID"].ToString(),
                        MemberName = dr["MemberName"].ToString(),
                        SlotName = dr["SLOTNAME"].ToString(),
                        StartTime = dr["STARTTIME"] != DBNull.Value ? (TimeSpan)dr["STARTTIME"] : (TimeSpan?)null,
                        TrainerName = dr["TrainerName"].ToString(),
                        PackageName = dr["PACKAGENAME"].ToString(),
                        RegID = Convert.ToInt32(dr["REGID"]),
                        OriginalDate = dr["ORIGINAL_DATE"] != DBNull.Value ? Convert.ToDateTime(dr["ORIGINAL_DATE"]) : (DateTime?)null
                    });
                }
            }
            catch (Exception) { throw; }
            return list;
        }
        public bool UpdateStatus(int scheduleId, string status, string notes)
        {
            string sql = "UPDATE SCHEDULES SET STATUS = @Status, NOTES = @Notes WHERE SCHEDULEID = @ID";
            SqlParameter[] parameters = {
                new SqlParameter("@Status", status),
                new SqlParameter("@Notes", notes),
                new SqlParameter("@ID", scheduleId)
            };
            return ExecuteNonQuery(sql, parameters) > 0;
        }

        // 3. Xóa lịch Scheduled trong tương lai (Dùng khi sửa/xóa Registration)
        public void DeleteFutureScheduled(int regId, DateTime fromDate)
        {
            string sql = "DELETE FROM SCHEDULES WHERE REGID = @RegID AND TRAININGDATE >= @FromDate AND STATUS = 'Scheduled'";
            SqlParameter[] parameters = {
                new SqlParameter("@RegID", regId),
                new SqlParameter("@FromDate", fromDate.Date)
            };
            ExecuteNonQuery(sql, parameters);
        }

        // 4. Thêm mới một buổi tập (Dùng cho hàm Generate hoặc Tạo buổi bù)
        public bool Insert(ScheduleDTO item)
        {
            string sql = @"INSERT INTO SCHEDULES (REGID, SLOTID, TRAININGDATE, STATUS, NOTES, IS_MAKEUP, ORIGINAL_DATE, MAKEUP_FOR_SCHEDULEID)
                           VALUES (@RegID, @SlotID, @Date, @Status, @Notes, @IsMakeup, @OrigDate, @MakeupID)";
            SqlParameter[] parameters = {
                new SqlParameter("@RegID", item.RegID),
                new SqlParameter("@SlotID", (object)item.SlotID ?? DBNull.Value),
                new SqlParameter("@Date", item.TrainingDate.Date),
                new SqlParameter("@Status", item.Status),
                new SqlParameter("@Notes", (object)item.Notes ?? DBNull.Value),
                new SqlParameter("@IsMakeup", item.IsMakeup),
                new SqlParameter("@OrigDate", (object)item.OriginalDate ?? DBNull.Value),
                new SqlParameter("@MakeupID", (object)item.MakeupForScheduleID ?? DBNull.Value)
            };
            return ExecuteNonQuery(sql, parameters) > 0;
        }

        // 5. Tự động chuyển Scheduled quá hạn thành Absent
        public void AutoMarkAbsent()
        {
            string sql = "UPDATE SCHEDULES SET STATUS = 'Absent' WHERE TRAININGDATE < CAST(GETDATE() AS DATE) AND STATUS = 'Scheduled'";
            ExecuteNonQuery(sql);
        }

        public DataTable GetSlotsForCombobox()
        {
            string sql = "SELECT SLOTID, SLOTNAME FROM TIMESLOTS ORDER BY STARTTIME ASC";
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
