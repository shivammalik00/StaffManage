using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManage.Model
{
    public class AssignedtaskViewModel
    {
        public int StaffID { get; set; }

        public int TaskID { get; set; }

        public DateTime AssignedDate { get; set; }
        [Range(1, 8)]
        public double AsiggnedHours { get; set; }
    }
}
