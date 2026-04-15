using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopapp_GYM
{
    public class ScheduleDTO
    {
        public int ScheduleID { get; set; }
        public int RegID { get; set; }
        public int? SlotID { get; set; } // Nullable nếu là buổi bù tự do
        public DateTime TrainingDate { get; set; }
        public string Status { get; set; } // 'Scheduled', 'Completed', 'Absent', 'Cancelled'
        public string Notes { get; set; }
        public bool IsMakeup { get; set; }
        public DateTime? OriginalDate { get; set; } // Ngày bị lỡ nếu là tập bù
        public string Reason { get; set; }
        public int? MakeupForScheduleID { get; set; }
    }
}
