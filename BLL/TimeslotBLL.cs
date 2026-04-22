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
    public class TimeslotBLL
    {
        TimeslotDAL dal = new TimeslotDAL();
        public List<TimeslotDTO> GetAll()
        {
            try { return dal.GetAll(); }
            catch (Exception ex) { throw new Exception("Lỗi khi lấy danh sách khung giờ: " + ex.Message); }
        }

        public bool Save(TimeslotDTO ts, bool isAdd)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ts.SlotName))
                throw new Exception("Vui lòng nhập tên lớp học!");
                if (ts.TrainerID <= 0)
                    throw new Exception("Vui lòng chọn Huấn luyện viên!");
                if (ts.PackageID <= 0)
                    throw new Exception("Vui lòng chọn Gói tập!");

                if (ts.MaxMembers <= 0)
                    throw new Exception("Sức chứa phải lớn hơn 0!");

                if (!isAdd) 
                {
                    int actualCount = dal.GetCurrentCount(ts.SlotID);

                    if (ts.MaxMembers < actualCount)
                    {
                        throw new Exception($"Không thể giảm sức chứa xuống {ts.MaxMembers} " +
                                            $"vì hiện đang có {actualCount} học viên đang đăng ký!");
                    }
                }

                return dal.Save(ts, isAdd);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi save: "+ ex.Message);
            }
        }

        public bool Delete(TimeslotDTO ts)
        {
            try
            {
                if (ts == null) return false;

                int actualCount = dal.GetCurrentCount(ts.SlotID);
                if (actualCount > 0)
                    throw new Exception($"Lớp này đang có {actualCount} học viên. Hãy hủy lịch của họ trước khi xóa khung giờ!");

                return dal.Delete(ts.SlotID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetTrainersByPackage(int packageId)
        {
            try { return dal.GetTrainersByPackage(packageId); }
            catch (Exception ex) { throw new Exception("Lỗi khi lấy danh sách HLV theo gói: " + ex.Message); }
        }
        public List<int> GetSlotIdsByMember(int memberId)
        {
            try { return dal.GetSlotIdsByMember(memberId); }
            catch (Exception ex) { throw new Exception("Lỗi khi lấy danh sách Slot của hội viên: " + ex.Message); }
        }

        public List<TimeslotDTO> GetByTrainerPackageDay(int trainerId, int packageId, string dayOfWeek)
        {
            try
            {
                if (trainerId <= 0 || packageId <= 0 || string.IsNullOrWhiteSpace(dayOfWeek))
                    return new List<TimeslotDTO>();
                return dal.GetByTrainerPackageDay(trainerId, packageId, dayOfWeek);
            }
            catch (Exception ex) { throw new Exception("Lỗi khi lọc danh sách khung giờ: " + ex.Message); }
        }

        public List<string> GetDaysByTrainerPackage(int trainerId, int packageId)
        {
            try
            {
                if (trainerId <= 0 || packageId <= 0) return new List<string>();
                return dal.GetDaysByTrainerPackage(trainerId, packageId);
            }
            catch (Exception ex) { throw new Exception("Lỗi khi lấy danh sách ngày tập: " + ex.Message); }
        }

        public bool CheckIsFull(int slotId, int maxMembers)
        {
            try { return dal.IsSlotFull(slotId, maxMembers); }
            catch (Exception ex) { throw new Exception("Lỗi khi kiểm tra sĩ số lớp: " + ex.Message); }
        }

        public int GetActualCurrentCount(int slotId)
        {
            try { return dal.GetCurrentCount(slotId); }
            catch (Exception ex) { throw new Exception("Lỗi khi lấy sĩ số thực tế: " + ex.Message); }
        }

        public bool RefreshSlotAttendance(int slotID)
        {
            try { return dal.SyncCurrentCount(slotID); }
            catch (Exception ex) { throw new Exception("Lỗi đồng bộ sĩ số lớp: " + ex.Message); }
        }

        public void RefreshAllAttendance()
        {
            try { dal.SyncAllAttendance(); }
            catch (Exception ex) { throw new Exception("Lỗi đồng bộ toàn bộ sĩ số: " + ex.Message); }
        }

        public DataTable GetTimeslotsToday()
        {
            try { return dal.GetTimeslotsToday(); }
            catch (Exception ex) { throw new Exception("Lỗi khi lấy lịch tập hôm nay: " + ex.Message); }
        }

    }
}
