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

        public UserDTO Login(string u, string p)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(u) || string.IsNullOrWhiteSpace(p))
                    throw new Exception("Tên đăng nhập và mật khẩu không được để trống!");

                var user = dal.CheckLogin(u, p);

                if (user == null)
                    throw new Exception("Tên đăng nhập hoặc mật khẩu không chính xác!");

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<UserDTO> GetAll()
        {
            try { return dal.GetAll(); }
            catch (Exception ex) { throw new Exception("Lỗi tải danh sách người dùng: " + ex.Message); }
        }

        public bool Save(UserDTO user, bool isAdd)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(user.Username))
                throw new Exception("Vui lòng nhập tên đăng nhập!");
                if (string.IsNullOrWhiteSpace(user.Role))
                    throw new Exception("Vui lòng chọn vai trò!");
                if (isAdd && string.IsNullOrWhiteSpace(user.Password))
                    throw new Exception("Vui lòng nhập mật khẩu!");
                
                return dal.Save(user, isAdd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Delete(UserDTO user)
        {
            try
            {
                if (user.Username.ToLower() == "admin")
                    throw new Exception("Không thể xóa tài khoản Admin hệ thống!");

                return dal.Delete(user.UserID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ResetPassword(int userId, string newPassword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(newPassword) || newPassword.Length < 4)
                    throw new Exception("Mật khẩu mới phải có ít nhất 4 ký tự!");

                return dal.ResetPassword(userId, newPassword);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool VerifyOldPassword(string username, string oldPassword)
        {
            try { return dal.VerifyOldPassword(username, oldPassword); }
            catch { return false; }
        }

    }
}
