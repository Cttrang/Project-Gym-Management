using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopapp_GYM.DTO
{
    public class MemberDTO
    {
        public int ID { get; set; }
        public int MemberID => ID;
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; } // Chỉ nhận "Member" hoặc "Trainer"
        public string Status { get; set; }
        public string GhiChu { get; set; }
        public int PackageID { get; set; }
        public int? TrainerID { get; set; }
        public DateTime RegDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime JoinDate { get; set; }

    }
}
