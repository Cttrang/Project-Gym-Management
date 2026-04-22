using desktopapp_GYM.DAL;
using desktopapp_GYM.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;


namespace desktopapp_GYM.BLL
{
    public class RegistrationBLL
    {
        private readonly RegistrationDAL dal = new RegistrationDAL();
        private readonly MemberDal memberDal = new MemberDal();
        private readonly TimeslotBLL timeslotBll = new TimeslotBLL(); // Thêm dòng này
        public List<RegistrationDTO> GetAll()
        {
            try { return dal.GetAll(); }
            catch (Exception ex) { throw new Exception("Lỗi khi lấy danh sách đăng ký: " + ex.Message); }
        }

        public List<RegistrationDTO> GetByMember(int memberId)
        {
            try { return dal.GetByMember(memberId); }
            catch (Exception ex) { throw new Exception("Lỗi khi lấy thông tin đăng ký của hội viên: " + ex.Message); }
        }

        public List<RegistrationSlotDTO> GetSlotsByReg(int regId)
        {
            try { return dal.GetSlotsByReg(regId); }
            catch (Exception ex) { throw new Exception("Lỗi khi lấy danh sách khung giờ: " + ex.Message); }
        }

        public bool RegisterFullService(MemberDTO member, RegistrationDTO reg)
        {
            // TransactionScope đảm bảo tất cả các lệnh bên trong đều thành công hoặc tất cả đều hủy
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    int newMemberId = memberDal.InsertAndGetID(member);
                    if (newMemberId <= 0)
                    {
                        MessageBox.Show("Tạo hội viên mới thất bại!");
                        return false;
                    }    
                        
                    reg.MemberID = newMemberId;

                    bool saveReg = Save(reg, true);

                    if (saveReg)
                    {
                        scope.Complete();
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi đăng ký trọn gói: " + ex.Message);
                }
            }
        }

        public bool Save(RegistrationDTO reg, bool isAdd)
        {
            try
            {
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

                if (result && reg.SelectedSlotIDs != null && reg.SelectedSlotIDs.Count > 0)
                {
                    try
                    {
                        foreach (int slotId in reg.SelectedSlotIDs)
                        {
                            timeslotBll.RefreshSlotAttendance(slotId);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lưu thành công nhưng lỗi cập nhật sĩ số: " + ex.Message);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu đăng ký: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Delete(int regId)
        {
            try
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
                    catch (Exception ex)
                    {
                        Console.WriteLine("Lỗi cập nhật sĩ số: " + ex.Message);
                    }

                }
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa đăng ký: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool DecreaseSession(int regId)
        {
            try { return dal.DecreaseSession(regId); }
            catch (Exception ex) { throw new Exception("Lỗi khi trừ buổi tập: " + ex.Message); }
        }

        public DataTable GetRevenueDetail()
        {
            try { return dal.GetRevenueDetail(); }
            catch (Exception ex) { throw new Exception("Lỗi khi lấy dữ liệu doanh thu: " + ex.Message); }
        }

    }
}
