using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManage.Models
{
    public class TaskDetails
    {
        public int ID { get; set; }

        public string Name { get; set; }
        [Range(1,8)]
        public double Hour { get; set; }

        public bool Iscompleted { get; set; }

        public DateTime DateCreated { get; set; }


    }
}
