using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopapp_GYM.DTO
{
    public class RegistrationDTO
    {
        public int RegID { get; set; }
        public int MemberID { get; set; }
        public string MemberName { get; set; }      // JOIN MEMBERS
        public int PackageID { get; set; }
        public string PackageName { get; set; }     // JOIN PACKAGES
        public string PackageType { get; set; }
        public int? TrainerID { get; set; }
        public string TrainerName { get; set; }     // JOIN TRAINERS

        public DateTime RegDate { get; set; }
        public DateTime EndDate { get; set; }

        public decimal TotalAmount { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal DiscountAmount { get; set; }

        public string PaymentStatus { get; set; }

        public int SessionsTotal { get; set; }
        public int SessionsLeft { get; set; }

        public bool IsActive { get; set; }
        public string Notes { get; set; }

        // Dùng khi add/edit — không lưu DB trực tiếp
        public List<int> SelectedSlotIDs { get; set; } = new List<int>();
        public string SlotSummary { get; set; }
    }
}
