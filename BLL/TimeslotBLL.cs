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
            if (string.IsNullOrWhiteSpace(ts.SlotName))
                throw new Exception("Vui lòng nhập tên khung giờ!");
            if (ts.TrainerID <= 0)
                throw new Exception("Vui lòng chọn Huấn luyện viên!");
            if (ts.PackageID <= 0)
                throw new Exception("Vui lòng chọn Gói tập!");
            if (ts.MaxMembers <= 0)
                throw new Exception("Số học viên tối đa phải lớn hơn 0!");
            return dal.Save(ts, isAdd);
        }

        public bool Delete(TimeslotDTO ts)
        {
            if (ts.CurrentCount > 0)
                throw new Exception(
                    $"Khung giờ này còn {ts.CurrentCount} lịch tập đang hoạt động. Không thể xóa!");
            return dal.Delete(ts.SlotID);
        }

        public DataTable GetTrainersByPackage(int packageId)
            => dal.GetTrainersByPackage(packageId);

    }
}
