using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopapp_GYM
{
    public class ScheduleViewDTO
    {
        // Các cột hiển thị trên GridView
        public int ScheduleID { get; set; }
        public int? SlotID { get; set; }
        public DateTime TrainingDate { get; set; }
        public string MemberName { get; set; }
        public string SlotName { get; set; }
        public string TrainerName { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public bool IsMakeup { get; set; }

        // Các thông tin bổ sung để đổ vào panel "Chi tiết buổi tập" bên phải
        public string MemberID_Display { get; set; } // Dùng cho label Member ID
        public string PackageName { get; set; }      // Tên gói tập
        public TimeSpan? StartTime { get; set; }     // Để hiện "Giờ"
        public DateTime? OriginalDate { get; set; }  // "Bù cho buổi..."

        // Thuộc tính hỗ trợ tính toán Label (Tổng/Attended/Absent)
        public int RegID { get; set; }
    }
}
