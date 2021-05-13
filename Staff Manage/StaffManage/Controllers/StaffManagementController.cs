using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StaffManage.Model;
using StaffManage.Models;
using StaffManage.RepositoryData;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManage.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StaffManagementController : Controller
    {
        private readonly IRepository _repo;


        public StaffManagementController(IRepository repo)
        {
           
            _repo = repo;
        }
        [HttpGet]
        public string Get()
        {
            return "API Running...";
        }
        [HttpPost]
        [Route("CreateStaff")]
        [IgnoreAntiforgeryToken]
        public IActionResult CreateStaff(StaffDetail staff)
        {

            if (staff != null)
            {
                staff.IsAvailable = true;
                
                var res = _repo.CraeteStaff(staff);
                if (res == "Added")
                    return Ok();
                else
                    return StatusCode(500, "Internal Server Error. Something went Wrong!");
            }
            else
                return BadRequest();
        }
        [HttpPost]
        [Route("CreateTask")]
        public IActionResult CreateTask(TaskDetails Task)
        {

            if (Task != null)
            {
                Task.Iscompleted = false;
                var res = _repo.CreateTask(Task);
                if (res == "Added")
                    return Ok();
                else
                    return Content(res);
            }
            else
                return BadRequest();
        }
        [HttpPost]
        [Route("AssignTask")]
        public IActionResult AssignTask(AssignedtaskViewModel assignedTask)
        {
            if (assignedTask != null)
            {
                var res = _repo.AssignedTask(assignedTask);
                if (res == "Added")
                    return Ok();
                else
                    return Content(res);
            }
            else
                return BadRequest();
        }
        [HttpGet]
        [Route("GetWeeklyTasks")]
        public IActionResult GetWeeklyTasks()
        {
            var res = _repo.GetTasksWeekely();
            return Json(JsonConvert.SerializeObject(res));
        }
        [HttpGet]
        [Route("GetWeeklyHours")]
        public IActionResult GetWeeklyHours()
        {
            var res = _repo.GetHoursWeekly();
            return Json(res);
        }
        [HttpPut]
        [Route("UpdateTask")]
        public IActionResult UpdateTask(int taskId)
        {
            var res = _repo.UpdateTask(taskId);
            if (res == "Updated")
                return Ok();
            else return Content(res);
        }
        [HttpGet]
        [Route("GetActiveStaff")]
        public IActionResult GetActiveStaffList()
        {
            IEnumerable<StaffDetail> stafflist = _repo.GetActiveStaff();
            return Json(JsonConvert.SerializeObject(stafflist));
        }
        [HttpGet]
        [Route("GetActiveTasks")]
        public IActionResult GetActiveTaskList()
        {
            IEnumerable<TaskDetails> taskList = _repo.GetActiveTask();
            return Json(JsonConvert.SerializeObject(taskList));
        }
        [HttpGet]
        [Route("GetTaskRemainigTime")]
        public IActionResult GetTaskRemainigTime(int taskId)
        {
          var res=  _repo.TaskRemainTime(taskId);
            return Json(res);
        }
    }
}
