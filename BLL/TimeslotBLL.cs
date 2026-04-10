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

            if (!isAdd && ts.MaxMembers < ts.CurrentCount)
                throw new Exception($"Không thể giảm sức chứa xuống {ts.MaxMembers} vì đã có {ts.CurrentCount} học viên đăng ký!");

            // 3. Kiểm tra logic thời gian (Nếu cần)
            // Ví dụ: StartTime < EndTime

            return dal.Save(ts, isAdd);
        }

        public bool Delete(TimeslotDTO ts)
        {
            if (ts == null) return false;
            if (ts.CurrentCount > 0)
                throw new Exception($"Lớp này đang có {ts.CurrentCount} học viên. Hãy hủy lịch của họ trước khi xóa khung giờ!");

            return dal.Delete(ts.SlotID);
        }

        public DataTable GetTrainersByPackage(int packageId)
            => dal.GetTrainersByPackage(packageId);
        public List<int> GetSlotIdsByMember(int memberId)
        {
            return dal.GetSlotIdsByMember(memberId);
        }

    }
}
