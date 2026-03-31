using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopapp_GYM.DTO
{
    public class PackageDTO
    {
        public int PackageID { get; set; }
        public string PackageName { get; set; }
        public int DurationMonths { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public int TotalMembers { get; set; }
    }
}
