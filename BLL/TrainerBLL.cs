using desktopapp_GYM.DAL;
using desktopapp_GYM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopapp_GYM.BLL
{
    public class TrainerBLL
    {
        TrainerDAL dal = new TrainerDAL();

        public List<TrainerDTO> GetData() => dal.GetAllTrainers();

        public bool SaveTrainer(TrainerDTO tr, bool isAdd)
        {
            // Kiểm tra nghiệp vụ cơ bản
            if (string.IsNullOrWhiteSpace(tr.FullName)) return false;
            return dal.Save(tr, isAdd);
        }

        public bool DeleteTrainer(TrainerDTO tr)
        {
            // Kiểm tra quyền Admin (Sử dụng lớp Session giống PackageBLL của Huy)
            if (Session.CurrentRole == "Receptionist")
                throw new Exception("Bạn không có quyền thực hiện thao tác xóa!");

            // Chặn xóa nếu HLV đang dạy học viên
            if (tr.TotalStudents > 0)
                throw new Exception("Huấn luyện viên này đang có học viên theo học. Không thể xóa!");

            return dal.Delete(tr.TrainerID);
        }
    }
}
