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
        private RegistrationDAL _regDal = new RegistrationDAL();
        public List<ScheduleViewDTO> GetSchedules(DateTime date, int? trainerId = null, string status = null, int? memberId = null, int? slotId = null)
        {
            try
            {
                // Trước khi lấy, có thể gọi tự động dọn dẹp các buổi quá hạn thành Absent
                _dal.AutoMarkAbsent();
                return _dal.GetSchedules(date, trainerId, status, memberId, slotId);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách lịch tập: " + ex.Message);
            }
        }

        public void SyncScheduleForRegistration(int regId)
        {
            try
            {
                var reg = _regDal.GetByID(regId);

                if (reg == null || !reg.IsActive || reg.EndDate < DateTime.Today)
                {
                    _dal.DeleteFutureScheduled(regId, DateTime.Today);
                    return;
                }

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
            catch (Exception ex)
            {
                throw new Exception("Lỗi hệ thống khi đồng bộ lịch tập: " + ex.Message);
            }
        }

        public void RunMonthlyMaintenance()
        {
            try
            {
                var activeRegs = _regDal.GetAllActive();
                foreach (var reg in activeRegs)
                {
                    SyncScheduleForRegistration(reg.RegID);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi bảo trì lịch tập hàng tháng: " + ex.Message);
            }
        }

        public bool UpdateSessionStatus(int scheduleId, string status, string notes, int regId)
        {
            try
            {
                bool updateResult = _dal.UpdateStatus(scheduleId, status, notes);

                if (updateResult)
                {
                    if (status == "Attended" || status == "Absent")
                    {
                        _regDal.DecreaseSession(regId);
                    }
                }

                return updateResult;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật trạng thái buổi tập: " + ex.Message);
            }
        }

        public DataTable GetTrainerList()
        {
            try
            {
                return new TrainerDAL().GetTrainersForCombobox();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tải danh sách huấn luyện viên: " + ex.Message);
            }
        }
        public DataTable GetSlotList()
        {
            try
            {
                return _dal.GetSlotsForCombobox();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tải danh sách ca tập: " + ex.Message);
            }
        }
        public string GetVietnameseDayOfWeek(DayOfWeek day)
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
            try { _dal.AutoMarkAbsent(); }
            catch (Exception ex) { throw new Exception("Lỗi khi xử lý lịch quá hạn: " + ex.Message); }
        }

        public bool Insert(ScheduleDTO item)
        {
            try
            {
                if (item.TrainingDate.Date < DateTime.Today)
                {
                    return false;
                }

                if (_dal.HasScheduleInRange(item.RegID, item.TrainingDate, item.TrainingDate))
                {
                    // return false; 
                }

                bool result = _dal.Insert(item);
 
                // Nếu là tập bù (IsMakeup = true), chúng ta KHÔNG gọi _regDal.DecreaseSession(item.RegID).
                // Vì buổi tập này được tạo ra để "bù" cho một buổi Absent đã bị trừ điểm trước đó.

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm lịch tập mới: " + ex.Message);
            }
        }

        public List<TimeslotDTO> GetAvailableSlotsByPackage(int packageId)
        {
            try { return _dal.GetSlotsByPackage(packageId); }
            catch (Exception ex) { throw new Exception("Lỗi khi lấy danh sách ca tập: " + ex.Message); }
        }

    }
}
