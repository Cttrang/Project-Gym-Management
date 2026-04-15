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
        public List<TimeslotDTO> GetAll() => dal.GetAll();

        public bool Save(TimeslotDTO ts, bool isAdd)
        {
            // 1. Validation cơ bản
            if (string.IsNullOrWhiteSpace(ts.SlotName))
                throw new Exception("Vui lòng nhập tên lớp học!");
            if (ts.TrainerID <= 0)
                throw new Exception("Vui lòng chọn Huấn luyện viên!");
            if (ts.PackageID <= 0)
                throw new Exception("Vui lòng chọn Gói tập!");

            // 2. Kiểm tra sức chứa
            if (ts.MaxMembers <= 0)
                throw new Exception("Sức chứa phải lớn hơn 0!");

            if (!isAdd) // Trường hợp Update
            {
                // BLL tự đi lấy con số thực tế từ DB để đảm bảo không bị "qua mặt"
                int actualCount = dal.GetCurrentCount(ts.SlotID);

                if (ts.MaxMembers < actualCount)
                {
                    throw new Exception($"Không thể giảm sức chứa xuống {ts.MaxMembers} " +
                                        $"vì hiện đang có {actualCount} học viên đang đăng ký!");
                }
            }

            // 3. Kiểm tra logic thời gian (Nếu cần)
            // Ví dụ: StartTime < EndTime

            return dal.Save(ts, isAdd);
        }

        public bool Delete(TimeslotDTO ts)
        {
            if (ts == null) return false;

            int actualCount = dal.GetCurrentCount(ts.SlotID);
            if (actualCount > 0)
                throw new Exception($"Lớp này đang có {actualCount} học viên. Hãy hủy lịch của họ trước khi xóa khung giờ!");

            return dal.Delete(ts.SlotID);
        }

        public DataTable GetTrainersByPackage(int packageId)
            => dal.GetTrainersByPackage(packageId);
        public List<int> GetSlotIdsByMember(int memberId)
        {
            return dal.GetSlotIdsByMember(memberId);
        }

        public List<TimeslotDTO> GetByTrainerPackageDay(int trainerId, int packageId, string dayOfWeek)
        {
            if (trainerId <= 0 || packageId <= 0 || string.IsNullOrWhiteSpace(dayOfWeek))
                return new List<TimeslotDTO>();
            return dal.GetByTrainerPackageDay(trainerId, packageId, dayOfWeek);
        }

        public List<string> GetDaysByTrainerPackage(int trainerId, int packageId)
        {
            if (trainerId <= 0 || packageId <= 0) return new List<string>();
            return dal.GetDaysByTrainerPackage(trainerId, packageId);
        }

        public bool CheckIsFull(int slotId, int maxMembers)
        {
            // Gọi DAL để đếm số lượng thực tế tại thời điểm hiện tại
            return dal.IsSlotFull(slotId, maxMembers);
        }

        public int GetActualCurrentCount(int slotId)
        {
            return dal.GetCurrentCount(slotId);
        }

    }
}
