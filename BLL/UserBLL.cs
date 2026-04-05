using desktopapp_GYM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopapp_GYM.BLL
{
    public class UserBLL
    {
        DAL.UserDAL dal = new DAL.UserDAL();

        public string Login(string u, string p)
        {
            if (string.IsNullOrEmpty(u) || string.IsNullOrEmpty(p))
                return null; // Không cho phép để trống

            return dal.CheckLogin(u, p);
        }

        public List<UserDTO> GetAll() => dal.GetAll();

        public bool Save(UserDTO user, bool isAdd)
        {
            if (string.IsNullOrWhiteSpace(user.Username))
                throw new Exception("Vui lòng nhập tên đăng nhập!");
            if (string.IsNullOrWhiteSpace(user.Role))
                throw new Exception("Vui lòng chọn vai trò!");
            if (isAdd && string.IsNullOrWhiteSpace(user.Password))
                throw new Exception("Vui lòng nhập mật khẩu!");
            
            return dal.Save(user, isAdd);
        }

        public bool Delete(UserDTO user)
        {
            return dal.Delete(user.UserID);
        }

        public bool ResetPassword(int userId, string newPassword)
        {
            if (string.IsNullOrWhiteSpace(newPassword))
                throw new Exception("Mật khẩu mới không được để trống!");
            return dal.ResetPassword(userId, newPassword);
        }

        public bool VerifyOldPassword(string username, string oldPassword)
        {
            return dal.VerifyOldPassword(username, oldPassword);
        }

    }
}
