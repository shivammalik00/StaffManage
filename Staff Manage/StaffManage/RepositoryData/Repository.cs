//using StaffManage.Data;
using Microsoft.EntityFrameworkCore;
using StaffManage.Model;
using StaffManage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManage.RepositoryData
{
    /// <summary>
    /// Repositroy
    /// </summary>
    public class Repository : IRepository
    {


        private readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string AssignedTask(AssignedtaskViewModel assignedTask)
        {
            try
            {
                var staffid = _dbContext.StaffDetails.Where(x => x.ID == assignedTask.StaffID).FirstOrDefault();
                if (staffid.IsAvailable != false)
                {

                    var TaskIid = _dbContext.TaskDetails.Where(x => x.ID == assignedTask.TaskID).FirstOrDefault();
                    if (TaskIid.Hour >= assignedTask.AsiggnedHours)
                    {
                        AssignedTask astask = new AssignedTask
                        {
                            StaffID = staffid,
                            TaskID = TaskIid,
                            AsiggnedHours = assignedTask.AsiggnedHours,
                            AssignedDate = assignedTask.AssignedDate
                        };
                        var taskRemainingHour = (TaskIid.Hour - assignedTask.AsiggnedHours);
                        _dbContext.AssignedTasks.Add(astask);
                        _dbContext.TaskDetails.Where(x => x.ID == assignedTask.TaskID).ToList().ForEach(i => i.Hour = taskRemainingHour);
                        _dbContext.StaffDetails.Where(x => x.ID == assignedTask.StaffID).ToList().ForEach(i => i.IsAvailable = false);


                        _dbContext.SaveChanges();
                        return "Added";
                    }
                    else return "Please provide hours less than or equal to : " + TaskIid.Hour;
                }
                else
                    return "Staff is Already working on some task.";
            }
            catch (Exception ex)
            {
                return "Exception while assigning task" + ex.Source;
            }
        }

        /// <summary>
        /// Create Staff 
        /// </summary>
        /// <param name="staff"></param>
        /// <returns></returns>
        public string CraeteStaff(StaffDetail staff)
        {
            try
            {
                _dbContext.StaffDetails.Add(staff);
                _dbContext.SaveChanges();
                return "Added";
            }
            catch (Exception ex)
            {
                return "Exception while Creating Staff" + ex.Source;
            }
        }
        public string CreateTask(TaskDetails task)
        {
            try
            {
                _dbContext.TaskDetails.Add(task);
                _dbContext.SaveChanges();
                return "Added";
            }
            catch (Exception ex)
            {
                return "Exception while creating Task" + ex.Source;
            }
        }

        public IEnumerable<StaffDetail> GetActiveStaff()
        {
            return _dbContext.StaffDetails.Where(x => x.IsAvailable == true).ToList();
        }

        public IEnumerable<TaskDetails> GetActiveTask()
        {
            return _dbContext.TaskDetails.Where(x => x.Iscompleted == false && x.Hour != 0).ToList();
        }

        public double GetHoursWeekly()
        {
            var dateCriteria = DateTime.Now.Date.AddDays(-7);
            var hours = _dbContext.AssignedTasks.Include(d => d.TaskID).Where(d => d.AssignedDate >= dateCriteria).Sum(D => D.AsiggnedHours);
            return hours;
        }

        public IEnumerable<TaskDetails> GetTasksWeekely()
        {
            var dateCriteria = DateTime.Now.Date.AddDays(-7);
            var data = _dbContext.AssignedTasks.Include(d => d.TaskID).Where(d => d.AssignedDate >= dateCriteria && d.TaskID.Hour == 0).Select(d => new TaskDetails
            {
                Name = d.TaskID.Name,
                DateCreated = d.TaskID.DateCreated,
                ID = d.TaskID.ID,
                Hour = d.TaskID.Hour,
                Iscompleted = d.TaskID.Iscompleted
            }).ToList();
            return data;
        }

        public double TaskRemainTime(int taskId)
        {
            try
            {
                var res = _dbContext.TaskDetails.Where(x => x.ID == taskId).FirstOrDefault();
                return res.Hour;
            }
            catch (Exception ex)
            {

                return 00;

            }
        }

        public string UpdateTask(int taskId)
        {
            try
            {
                _dbContext.TaskDetails.Where(x => x.ID == taskId).ToList().ForEach(i => i.Iscompleted = true);
                _dbContext.AssignedTasks.Where(x => x.TaskID.ID == taskId).ToList().ForEach(s => s.StaffID.IsAvailable = true);
                _dbContext.SaveChanges();
                return "Updated";
            }
            catch (Exception ex)
            {
                return "Exception in Updating Task :" + ex.Source;
            }
        }
    }
}
