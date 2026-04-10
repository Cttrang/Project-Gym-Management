using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopapp_GYM.DTO
{
    public class TimeslotDTO
    {
        public int SlotID { get; set; }
        public int TrainerID { get; set; }
        public int PackageID { get; set; }
        public string TrainerName { get; set; }
        public string PackageName { get; set; }
        public string SlotName { get; set; }
        public string DayOfWeek { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int MaxMembers { get; set; }
        public int CurrentCount { get; set; } // số người đã đăng ký vào slot
        public string Status { get; set; }

        public string DisplayTime =>
        $"{StartTime}-{EndTime}  [{SlotName}]" +
        $"  ({CurrentCount}/{MaxMembers} chỗ)";
    }
}
