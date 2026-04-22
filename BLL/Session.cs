using desktopapp_GYM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopapp_GYM.BLL
{
    public static class Session
    {
        public static int CurrentUserID { get; set; }
        public static string CurrentUsername { get; set; } 
        public static string CurrentRole { get; set; } 
        public static DateTime LoginTime { get; set; }
        public static UserDTO CurrentUser { get; set; }
        public static void Clear()
        { 
            CurrentUserID = 0;
            CurrentUsername = null; 
            CurrentRole = null; 
            LoginTime = DateTime.MinValue; 
        }  
    }
}
