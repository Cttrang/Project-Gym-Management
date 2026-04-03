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
            if (dto.Role == "Member")
                return dal.SaveMember(dto, isAdd);

            else if (dto.Role == "Trainer")
            {
                // Chuyển MemberDTO sang TrainerDTO rồi gọi TrainerDAL.Save
                TrainerDTO trainerDto = new TrainerDTO
                {
                    TrainerID = dto.ID,
                    FullName = dto.FullName,
                    Phone = dto.Phone,
                    Specialty = dto.GhiChu,  // GhiChu = Specialty của Trainer
                    Status = dto.Status
                };
                return trainerDal.Save(trainerDto, isAdd);
            }

            return false;
        }

        public DataTable GetPackages() => dal.GetPackages();
        public DataTable GetTrainers() => dal.GetTrainers();
        public bool DeleteData(int id, string targetRole)
        {
            CheckStaffPermission(targetRole, "xóa");
            return dal.DeleteRecord(id, targetRole);
        }
    }
}
