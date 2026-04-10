using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopapp_GYM.DTO
{
    public class RegistrationSlotDTO
    {
        public int ID { get; set; }
        public int RegID { get; set; }
        public int SlotID { get; set; }
        public string SlotName { get; set; }
        public string DayOfWeek { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string TrainerName { get; set; }
    }
}
