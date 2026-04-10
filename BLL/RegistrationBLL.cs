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
    public class RegistrationBLL
    {
        private readonly RegistrationDAL dal = new RegistrationDAL();

        public List<RegistrationDTO> GetAll() => dal.GetAll();

        public List<RegistrationDTO> GetByMember(int memberId) => dal.GetByMember(memberId);

        public List<RegistrationSlotDTO> GetSlotsByReg(int regId) => dal.GetSlotsByReg(regId);

        public bool Save(RegistrationDTO reg, bool isAdd)
        {
            // Validate cơ bản
            if (reg.MemberID <= 0)
            {
                MessageBox.Show("Vui lòng chọn hội viên!", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (reg.PackageID <= 0)
            {
                MessageBox.Show("Vui lòng chọn gói tập!", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (reg.EndDate <= DateTime.Today)
            {
                MessageBox.Show("Ngày kết thúc phải sau ngày hôm nay!", "Ngày không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (reg.TotalAmount <= 0)
            {
                MessageBox.Show("Tổng tiền không hợp lệ!", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra trùng slot
            int excludeId = isAdd ? 0 : reg.RegID;
            foreach (int slotId in reg.SelectedSlotIDs)
            {
                if (dal.IsSlotConflict(reg.MemberID, slotId, excludeId))
                {
                    MessageBox.Show($"Hội viên đã đăng ký khung giờ này ở hợp đồng khác!",
                        "Trùng lịch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return dal.Save(reg, isAdd);
        }

        public bool Delete(int regId)
        {
            if (Session.CurrentRole == "Receptionist")
                throw new Exception("Bạn không có quyền xóa đăng ký!");
            return dal.Delete(regId);
        }
    }
}
