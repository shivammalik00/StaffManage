using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManage.Controllers
{
   [Authorize]
    public class StaffManagementUIController : Controller
    {
        [Route("AddStaff")]
        public IActionResult AddStaff()
        {
            return View();
        }
        [Route("AssignTask")]
        public IActionResult AssignTask()
        {
            return View();
        }
        [Route("AddTask")]

        public IActionResult AddTask()
        {
            return View();
        }
       

        public IActionResult Staff()
        {
            return View();
        }
        [Route("Task")]

        public IActionResult Task()
        {
            return View();
        }
        [Route("WeeklyTask")]

        public IActionResult WeeklyTask()
        {
            return View();
        }
        [Route("WeeklyHours")]

        public IActionResult WeeklyHours()
        {
            return View();
        }
    }
}
