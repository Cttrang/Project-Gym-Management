using desktopapp_GYM.DAL;
using desktopapp_GYM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopapp_GYM.BLL
{
    public class PackageBLL
    {
        PackageDAL dal = new PackageDAL();

        public List<PackageDTO> GetData() => dal.GetAllPackages();

        public bool SavePackage(PackageDTO pkg, bool isAdd)
        {
            if (string.IsNullOrWhiteSpace(pkg.PackageName)) return false;
            return dal.Save(pkg, isAdd);
        }

        public bool DeletePackage(PackageDTO pkg)
        {
            if (Session.CurrentRole != "Admin")
                throw new Exception("Bạn không có quyền thực hiện thao tác xóa!");
            // Kiểm tra: Nếu số người đăng ký > 0 thì chặn xóa ngay tại BLL
            if (pkg.TotalMembers > 0)
                throw new Exception("Gói tập này đang có hội viên sử dụng. Không thể xóa!");

            return dal.Delete(pkg.PackageID);
        }
    }
}
