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
            // Kiểm tra cơ bản
            if (string.IsNullOrWhiteSpace(pkg.PackageName)) return false;

            // Logic nghiệp vụ: Nếu gói là PT hoặc CLASS thì bắt buộc phải có số buổi/tuần
            if (pkg.Type != "FREE" && (!pkg.PTSessionsPerWeek.HasValue || pkg.PTSessionsPerWeek <= 0))
            {
                throw new Exception("Gói tập PT hoặc CLASS cần nhập số buổi mỗi tuần!");
            }

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

        public int CalculateTotalSessions(PackageDTO pkg)
        {
            if (pkg.Type == "FREE" || !pkg.PTSessionsPerWeek.HasValue)
                return 0;

            // Công thức trung bình 52 tuần: (Số buổi/tuần * 52) / 12 * Số tháng
            double avgSessionsPerMonth = (pkg.PTSessionsPerWeek.Value * 52.0) / 12.0;
            double total = avgSessionsPerMonth * pkg.DurationMonths;

            // Làm tròn lên (Ceiling) để đảm bảo quyền lợi hội viên
            return (int)Math.Ceiling(total);
        }

    }
}
