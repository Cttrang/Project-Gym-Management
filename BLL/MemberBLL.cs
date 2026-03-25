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

        public DataTable GetAllEveryone()
        {
            return dal.GetAllEveryone();
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
        public bool SaveData(MemberDTO dto, bool isAdd) => dal.SaveMember(dto, isAdd);
        public DataTable GetPackages() => dal.GetPackages();
        public DataTable GetTrainers() => dal.GetTrainers();
        public bool DeleteData(int id, string type)
        {
            // BLL nhận lệnh từ GUI và chuyển tiếp xuống DAL
            return dal.DeleteRecord(id, type);
        }
    }
}
