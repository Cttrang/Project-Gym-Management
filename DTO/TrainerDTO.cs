using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopapp_GYM.DTO
{
    public class TrainerDTO
    {
        public int TrainerID { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Specialty { get; set; }
        public string Status { get; set; }
        public int TotalStudents { get; set; }
    }
}
