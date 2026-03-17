using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopapp_GYM.BLL
{
    public static class Session
    {
        // Lưu tên đăng nhập (Ví dụ: admin, letan1...)
        public static string CurrentUsername { get; set; } 
        // Lưu quyền hạn (Ví dụ: Admin, Manager, Receptionist)
        public static string CurrentRole { get; set; } 
        // Lưu thời điểm đăng nhập (Dùng để hiển thị lên Dashboard cho chuyên nghiệp)
        public static DateTime LoginTime { get; set; } 
        // Hàm xóa session khi người dùng nhấn "Đăng xuất" (Logout)
        public static void Clear()
        { 
            CurrentUsername = null; 
            CurrentRole = null; 
            LoginTime = DateTime.MinValue; 
        }  
    }
}
