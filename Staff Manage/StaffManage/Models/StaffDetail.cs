using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManage.Models
{
    public class StaffDetail
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [Range(1,8)]
        public double HoursAvailable { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsAvailable { get; set; }
    }
}
