using desktopapp_GYM.DAL;
using desktopapp_GYM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desktopapp_GYM.BLL
{
    public class TrainerBLL
    {
        TrainerDAL dal = new TrainerDAL();

        public List<TrainerDTO> GetData()
        {
            try
            {
                return dal.GetAllTrainers();
            }
            catch (Exception ex)
            {
                throw new Exception("Không thể lấy danh sách huấn luyện viên: " + ex.Message);
            }
        }

        public bool SaveTrainer(TrainerDTO tr, bool isAdd)
        {
            if (string.IsNullOrWhiteSpace(tr.FullName)) return false;
            return dal.Save(tr, isAdd);
        }

        public bool DeleteTrainer(TrainerDTO tr)
        {
            try
            {
                if (Session.CurrentRole == "Receptionist")
                throw new Exception("Bạn không có quyền thực hiện thao tác xóa!");

                if (tr.TotalStudents > 0)
                    throw new Exception("Huấn luyện viên này đang có học viên theo học. Không thể xóa!");

                return dal.Delete(tr.TrainerID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<int> GetPackageIdsByTrainer(int trainerId)
        {
            try
            {
                if (trainerId <= 0) return new List<int>();
                return dal.GetPackageIdsByTrainer(trainerId);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tải danh sách gói tập của HLV: " + ex.Message);
            }
        }

        public bool SaveTrainerWithPackages(TrainerDTO tr, List<int> packageIds, bool isAdd)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tr.FullName)) return false;
                if (packageIds == null || packageIds.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất 1 gói tập cho HLV!",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                return dal.SaveWithPackages(tr, packageIds, isAdd);
            }
            catch (Exception ex)
            {
                // Ném lỗi ra cho GUI xử lý
                throw new Exception("Có lỗi khi lưu trainer cùng với gói" + ex.Message);
            }
        }

    }
}
