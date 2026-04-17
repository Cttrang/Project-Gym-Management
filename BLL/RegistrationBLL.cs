using desktopapp_GYM.DAL;
using desktopapp_GYM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Transactions;


namespace desktopapp_GYM.BLL
{
    public class RegistrationBLL
    {
        private readonly RegistrationDAL dal = new RegistrationDAL();
        private readonly MemberDal memberDal = new MemberDal();
        private readonly TimeslotBLL timeslotBll = new TimeslotBLL(); // Thêm dòng này
        public List<RegistrationDTO> GetAll() => dal.GetAll();

        public List<RegistrationDTO> GetByMember(int memberId) => dal.GetByMember(memberId);

        public List<RegistrationSlotDTO> GetSlotsByReg(int regId) => dal.GetSlotsByReg(regId);

        public bool RegisterFullService(MemberDTO member, RegistrationDTO reg)
        {
            // TransactionScope đảm bảo tất cả các lệnh bên trong đều thành công hoặc tất cả đều hủy
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    // 1. Lưu Member mới và lấy ID trả về
                    int newMemberId = memberDal.InsertAndGetID(member);
                    if (newMemberId <= 0)
                    {
                        MessageBox.Show("Tạo hội viên mới thất bại!");
                        return false;
                    }    
                        
                    // 2. Gán ID vừa tạo cho Registration
                    reg.MemberID = newMemberId;

                    // 3. Gọi hàm Save có sẵn (hàm này sẽ tự dùng logic của nó)
                    // Vì nằm trong TransactionScope, nó sẽ tự động tham gia vào giao dịch chung
                    bool saveReg = Save(reg, true);

                    if (saveReg)
                    {
                        // 4. CHỐT HẠ: Xác nhận mọi thứ thành công
                        scope.Complete();
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    // Nếu lỗi, không gọi scope.Complete(), mọi thứ sẽ tự Rollback
                    throw new Exception("Lỗi đăng ký trọn gói: " + ex.Message);
                }
            }
        }

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

            bool result = dal.Save(reg, isAdd);

            // 4. Nếu lưu thành công, tiến hành đồng bộ số lượng người ở bảng TimeSlot
            if (result && reg.SelectedSlotIDs != null && reg.SelectedSlotIDs.Count > 0)
            {
                try
                {
                    foreach (int slotId in reg.SelectedSlotIDs)
                    {
                        // Gọi hàm refresh từ TimeSlotBLL để tính toán lại số người đang tập
                        timeslotBll.RefreshSlotAttendance(slotId);
                    }
                }
                catch (Exception ex)
                {
                    // Không nên chặn return true nếu chỉ lỗi refresh, nhưng nên thông báo lỗi
                    MessageBox.Show("Lưu thành công nhưng lỗi cập nhật sĩ số: " + ex.Message);
                }
            }

            return result;
        }

        public bool Delete(int regId)
        {
            if (Session.CurrentRole == "Receptionist")
                throw new Exception("Bạn không có quyền xóa đăng ký!");
            var relatedSlots = dal.GetSlotsByReg(regId).Select(s => s.SlotID).ToList();

            bool result = dal.Delete(regId);

            if (result)
            {
                try
                {
                    foreach (int slotId in relatedSlots)
                    {
                        timeslotBll.RefreshSlotAttendance(slotId);
                    }
                }
                catch { /* Log lỗi hoặc bỏ qua để tránh gây nhiễu người dùng */ }

            }
            return result;
        }

        // Trong RegistrationBLL.cs
        
    }
}
