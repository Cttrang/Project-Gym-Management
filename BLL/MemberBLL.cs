using desktopapp_GYM.DAL;
using desktopapp_GYM.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desktopapp_GYM.BLL
{
    public class MemberBLL
    {
        MemberDal dal = new MemberDal();
        TrainerDAL trainerDal = new TrainerDAL();

        public DataTable GetAllEveryone()
        {
            return dal.GetAllEveryone();
        }

        public int UpdateExpiredStatus()
        {
            return dal.UpdateExpiredStatus();
        }

        public DataTable SearchData(string keyword)
        {
            return dal.SearchEveryone(keyword);
        }

        private int GetRoleLevel(string role)
        {
            switch (role)
            {
                case "Admin": return 3;
                case "Manager": return 2;
                case "Receptionist": return 1;
                default: return 0; // Member hoặc Trainer
            }
        }

        public bool HasPermission(string loginRole, string targetRole, string action)
        {
            // 1. Admin luôn có quyền với mọi đối tượng
            if (loginRole == "Admin") return true;

            int loginLevel = GetRoleLevel(loginRole);
            int targetLevel = GetRoleLevel(targetRole);

            // 2. Logic: Không được tác động (Add/Edit/Delete) người có Role ngang hoặc cao hơn mình
            if (loginLevel <= targetLevel)
            {
                return false;
            }

            // 3. Các trường hợp còn lại (Cấp cao tác động cấp thấp) -> Hợp lệ
            return true;
        }

        private void CheckStaffPermission(string targetRole, string action)
        {
            string[] staffRoles = { "Admin", "Manager", "Receptionist" };
            if (staffRoles.Contains(targetRole))
            {
                if (!HasPermission(Session.CurrentRole, targetRole, action))
                    throw new Exception(
                        $"Bạn không có quyền {action} tài khoản có vai trò {targetRole}!");
            }
        }

        public bool SaveData(MemberDTO dto, bool isAdd)
        {
            try
            {
                if (dto.Role == "Member")
                     return dal.SaveMember(dto, isAdd);

                 else if (dto.Role == "Trainer")
                 {
                     TrainerDTO trainerDto = new TrainerDTO
                     {
                         TrainerID = dto.ID,
                         FullName = dto.FullName,
                         Phone = dto.Phone,
                         Specialty = dto.GhiChu,  //GhiChu = Specialty của Trainer
                         Status = dto.Status
                     };
                     return trainerDal.Save(trainerDto, isAdd);
                 }

                 return false;
            }
            catch (Exception ex)
            {
                // Ném các lỗi logic khác ra UI
                throw new Exception("Lỗi khi lưu dữ liệu: " + ex.Message);
            }
        }

        public DataTable GetPackages() => dal.GetPackages();
        public DataTable GetTrainers() => dal.GetTrainers();
        public bool DeleteData(int id, string targetRole)
        {
            try
            {
                CheckStaffPermission(targetRole, "xóa");
            if (targetRole == "Member")
            {
                if (dal.GetMemberStatus(id) == "Paid")
                {
                    throw new Exception("Hội viên đã thanh toán phí tập. Không thể xóa để đảm bảo tính minh bạch tài chính!");
                }
            }
            else if (targetRole != "Admin" && targetRole != "Manager")
            {
                if (dal.GetTrainerStudentCount(id) > 0)
                {
                    throw new Exception("Huấn luyện viên này đang có học viên theo học. Không thể xóa!");
                }
            }
            
            return dal.DeleteRecord(id, targetRole);
            }
            catch (Exception ex)
            {
                // Đảm bảo mọi lỗi (quyền hạn, logic, database) đều được đưa về một đầu mối
                throw new Exception("Không thể lưu: " + ex.Message);
            }
        }

        public MemberDTO GetById(int memberId)
        {
            if (memberId <= 0) return null;
            return dal.GetById(memberId);
        }

        public int AddAndGetID(MemberDTO m)
        {
            if (string.IsNullOrWhiteSpace(m.FullName))
            {
                MessageBox.Show("Họ tên không được để trống!",
                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
            if (string.IsNullOrWhiteSpace(m.Phone))
            {
                MessageBox.Show("Số điện thoại không được để trống!",
                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
            try
            {
                return dal.InsertAndGetID(m);
            }
            catch (Exception ex)
            {
                // Thường là lỗi UNIQUE constraint trên PHONE
                if (ex.Message.Contains("UNIQUE"))
                    throw new Exception("Số điện thoại này đã được đăng ký bởi hội viên khác!");

                throw new Exception("Không thể tạo hội viên mới: " + ex.Message);
            }
        }

        public List<MemberDTO> GetData() => dal.GetAllMembers();
    }
}
