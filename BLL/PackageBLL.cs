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

        public List<PackageDTO> GetData()
        {
            try
            {
                return dal.GetAllPackages();
            }
            catch (Exception ex)
            {
                throw new Exception("Không thể lấy danh sách gói tập: " + ex.Message);
            }
        }

        public bool SavePackage(PackageDTO pkg, bool isAdd)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(pkg.PackageName)) return false;
                if (pkg.Type != "FREE" && (!pkg.PTSessionsPerWeek.HasValue || pkg.PTSessionsPerWeek <= 0))
                {
                    throw new Exception("Gói tập PT hoặc CLASS cần nhập số buổi mỗi tuần!");
                }

                return dal.Save(pkg, isAdd);
            }
            catch (Exception ex)
            {
                throw new Exception("Lưu dữ liệu thất bại tại hệ thống!" + ex.Message);
            }
        }

        public bool DeletePackage(PackageDTO pkg)
        {
            try
            {
                if (Session.CurrentRole != "Admin")
                    throw new Exception("Bạn không có quyền thực hiện thao tác xóa!");
                if (pkg.TotalMembers > 0)
                    throw new Exception("Gói tập này đang có hội viên sử dụng. Không thể xóa!");
                return dal.Delete(pkg.PackageID);
                }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int CalculateTotalSessions(PackageDTO pkg)
        {
            try
            {
                if (pkg.Type == "FREE" || !pkg.PTSessionsPerWeek.HasValue)
                return 0;

            // Công thức trung bình 52 tuần: (Số buổi/tuần * 52) / 12 * Số tháng
                double avgSessionsPerMonth = (pkg.PTSessionsPerWeek.Value * 52.0) / 12.0;
                double total = avgSessionsPerMonth * pkg.DurationMonths;

                return (int)Math.Ceiling(total);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tính toán Sessions: " + ex.Message);
                return 0;
            }
        }

        public List<PackageDTO> GetPackagesByTrainer(int trainerId) => dal.GetPackagesByTrainer(trainerId);
        public List<PackageDTO> GetByType(string type) => dal.GetByType(type);
        public PackageDTO GetById(int id)
        {
            try
            {
                if (id <= 0) return null;
                return dal.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm gói tập: " + ex.Message);
            }
        }
    }
}
