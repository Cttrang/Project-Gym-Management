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
    }
}
