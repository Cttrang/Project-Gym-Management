using desktopapp_GYM.DAL;
using desktopapp_GYM.DTO;
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
        public List<ScheduleViewDTO> GetSchedules(DateTime date, int? trainerId = null, string status = null, int? memberId = null, int? slotId = null)
        {
            // Trước khi lấy, có thể gọi tự động dọn dẹp các buổi quá hạn thành Absent
            _dal.AutoMarkAbsent();
            return _dal.GetSchedules(date, trainerId, status, memberId, slotId);
        }

        // 2. HÀM QUAN TRỌNG: Đồng bộ lịch khi Đăng ký mới/Sửa/Xóa (Sync)
        public void SyncScheduleForRegistration(int regId)
        {
            var reg = _regDal.GetByID(regId);

            if (reg == null || !reg.IsActive || reg.EndDate < DateTime.Today)
            {
                _dal.DeleteFutureScheduled(regId, DateTime.Today);
                return;
            }

            // Xác định tháng hiện tại đã có lịch chưa
            DateTime firstDayThisMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime lastDayThisMonth = firstDayThisMonth.AddMonths(1).AddDays(-1);
            DateTime firstDayNextMonth = firstDayThisMonth.AddMonths(1);
            DateTime lastDayNextMonth = firstDayThisMonth.AddMonths(2).AddDays(-1);

            bool thisMonthHasSchedule = _dal.HasScheduleInRange(regId, firstDayThisMonth, lastDayThisMonth);

            // FIX: Nếu tháng này chưa có lịch, thay vì lấy firstDayThisMonth (ngày 1), 
            // ta lấy Max của (firstDayThisMonth và reg.StartDate) để không bị gen lùi về trước ngày đăng ký.
            DateTime actualStartThisMonth = firstDayThisMonth < reg.RegDate ? reg.RegDate : firstDayThisMonth;

            DateTime startGen = thisMonthHasSchedule ? firstDayNextMonth : actualStartThisMonth;
            DateTime endGen = lastDayNextMonth;

            if (startGen > reg.EndDate) return;
            endGen = endGen < reg.EndDate ? endGen : reg.EndDate;

            var selectedSlots = _regDal.GetSlotsByReg(regId);

            for (DateTime d = startGen; d <= endGen; d = d.AddDays(1))
            {
                // Kiểm tra bổ sung để chắc chắn không gen lịch trước ngày StartDate của gói
                if (d < reg.RegDate) continue;

                string vnDay = GetVietnameseDayOfWeek(d.DayOfWeek);
                var match = selectedSlots.FirstOrDefault(s => s.DayOfWeek == vnDay);
                if (match != null)
                {
                    _dal.Insert(new ScheduleDTO
                    {
                        RegID = regId,
                        SlotID = match.SlotID,
                        TrainingDate = d,
                        Status = "Scheduled",
                        IsMakeup = false
                    });
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
                if (status == "Attended" || status == "Absent")
                {
                    _regDal.DecreaseSession(regId);
                }
                // Nếu là "Cancelled" -> Không trừ buổi
            }

            return updateResult;
        }

        // Trong ScheduleBLL.cs
        public DataTable GetTrainerList() => new TrainerDAL().GetTrainersForCombobox(); // Giả sử bạn có TrainerDAL
        public DataTable GetSlotList() => _dal.GetSlotsForCombobox();
        private string GetVietnameseDayOfWeek(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Monday: return "Thứ 2";
                case DayOfWeek.Tuesday: return "Thứ 3";
                case DayOfWeek.Wednesday: return "Thứ 4";
                case DayOfWeek.Thursday: return "Thứ 5";
                case DayOfWeek.Friday: return "Thứ 6";
                case DayOfWeek.Saturday: return "Thứ 7";
                case DayOfWeek.Sunday: return "Chủ Nhật";
                default: return "";
            }
        }

        public void ProcessExpiredSchedules()
        {
            _dal.AutoMarkAbsent();
        }

        public bool Insert(ScheduleDTO item)
        {
            // 1. Kiểm tra ràng buộc: Không cho phép đặt lịch bù vào quá khứ
            if (item.TrainingDate.Date < DateTime.Today)
            {
                return false;
            }

            // 2. Kiểm tra xem ngày đó Member đã có lịch tập chưa (tránh trùng lịch cùng ngày)
            // Bạn có thể dùng lại hàm HasScheduleInRange đã có ở DAL
            if (_dal.HasScheduleInRange(item.RegID, item.TrainingDate, item.TrainingDate))
            {
                // Nếu đã có lịch rồi thì không cho chèn thêm (tùy nghiệp vụ phòng gym của bạn)
                // return false; 
            }

            // 3. Thực hiện chèn vào Database
            bool result = _dal.Insert(item);

            // 4. LOGIC QUAN TRỌNG: 
            // Nếu là tập bù (IsMakeup = true), chúng ta KHÔNG gọi _regDal.DecreaseSession(item.RegID).
            // Vì buổi tập này được tạo ra để "bù" cho một buổi Absent đã bị trừ điểm trước đó.

            return result;
        }

        // Thêm vào ScheduleBLL.cs
        public List<TimeslotDTO> GetAvailableSlotsByPackage(int packageId)
        {
            // Gọi xuống DAL để lấy các ca tập có PackageID tương ứng
            // Huy có thể cần viết hàm này trong DAL nếu chưa có
            return _dal.GetSlotsByPackage(packageId);
        }

    }
}
