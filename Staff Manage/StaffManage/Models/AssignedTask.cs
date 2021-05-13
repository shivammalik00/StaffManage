using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManage.Models
{
    public class AssignedTask
    {
        public int ID { get; set; }

        public StaffDetail StaffID { get; set; }

        public TaskDetails TaskID { get; set; }

        public DateTime AssignedDate { get; set; }
        [Range(1,8)]
        public double AsiggnedHours { get; set; }
    }
}
