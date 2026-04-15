using desktopapp_GYM.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopapp_GYM.BLL
{
    public class ScheduleBLL
    {
        private ScheduleDAL _dal = new ScheduleDAL();
        private RegistrationDAL _regDal = new RegistrationDAL(); // Để lấy thông tin EndDate, IsActive

        // 1. Lấy dữ liệu cho UI ucSchedules
        public List<ScheduleViewDTO> GetSchedules(DateTime date, int? trainerId = null, string status = null, int? memberId = null)
        {
            // Trước khi lấy, có thể gọi tự động dọn dẹp các buổi quá hạn thành Absent
            _dal.AutoMarkAbsent();
            return _dal.GetSchedules(date, trainerId, status, memberId);
        }

        // 2. HÀM QUAN TRỌNG: Đồng bộ lịch khi Đăng ký mới/Sửa/Xóa (Sync)
        public void SyncScheduleForRegistration(int regId)
        {
            // 1. Lấy thông tin Registration
            var reg = _regDal.GetByID(regId);

            // 2. Nếu không tìm thấy hoặc Inactive/Expired -> Xóa lịch Scheduled tương lai
            if (reg == null || !reg.IsActive || reg.EndDate < DateTime.Today)
            {
                _dal.DeleteFutureScheduled(regId, DateTime.Today);
                return;
            }

            // 3. Xác định mốc thời gian gối đầu (Tháng này + Tháng sau)
            DateTime startGen = (reg.RegDate > DateTime.Today) ? reg.RegDate : DateTime.Today;
            DateTime endOfNextMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1)
                                        .AddMonths(2).AddDays(-1);

            // 4. Xóa các bản ghi 'Scheduled' cũ từ hôm nay để nạp lại (tránh trùng hoặc đổi Slot)
            _dal.DeleteFutureScheduled(regId, DateTime.Today);

            // 5. Lấy danh sách các Thứ (DayOfWeek) mà khách đã chọn từ bảng Registration_Slots
            // Giả sử bạn có hàm GetSlotsByReg ở RegistrationDAL
            var selectedSlots = _regDal.GetSlotsByReg(regId);

            // 6. Vòng lặp tạo lịch
            for (DateTime d = startGen; d <= endOfNextMonth && d <= reg.EndDate; d = d.AddDays(1))
            {
                string dayOfWeek = d.DayOfWeek.ToString(); // "Monday", "Tuesday"...

                // Tìm xem ngày hiện tại có trùng với Thứ khách đã đăng ký không
                var match = selectedSlots.FirstOrDefault(s => s.DayOfWeek == dayOfWeek);

                if (match != null)
                {
                    ScheduleDTO item = new ScheduleDTO
                    {
                        RegID = regId,
                        SlotID = match.SlotID,
                        TrainingDate = d,
                        Status = "Scheduled",
                        IsMakeup = false
                    };
                    _dal.Insert(item);
                }
            }
        }

        // 3. Hàm chạy định kỳ đầu tháng (Maintenance)
        public void RunMonthlyMaintenance()
        {
            // Lấy tất cả các Registration đang hoạt động
            var activeRegs = _regDal.GetAllActive();
            foreach (var reg in activeRegs)
            {
                SyncScheduleForRegistration(reg.RegID);
            }
        }

        // 4. Xử lý điểm danh (Attended / Absent / Cancelled)
        public bool UpdateSessionStatus(int scheduleId, string status, string notes, int regId)
        {
            // Thực hiện update trạng thái buổi tập
            bool updateResult = _dal.UpdateStatus(scheduleId, status, notes);

            if (updateResult)
            {
                // Nếu là "Attended" hoặc "Absent" -> Trừ 1 buổi ở SessionsLeft trong Registration
                // (Vì theo logic của bạn, Absent vẫn mất buổi nhưng được bù sau)
                if (status == "Completed" || status == "Absent")
                {
                    _regDal.DecreaseSession(regId);
                }
                // Nếu là "Cancelled" -> Không trừ buổi
            }

            return updateResult;
        }

        // Trong ScheduleBLL.cs
        public DataTable GetTrainerList() => new TrainerDAL().GetTrainersForCombobox(); // Giả sử bạn có TrainerDAL
        public DataTable GetSlotList() => new DataConnection().ExecuteQuery("SELECT SLOTID, SLOTNAME FROM TIMESLOTS");
    }
}
