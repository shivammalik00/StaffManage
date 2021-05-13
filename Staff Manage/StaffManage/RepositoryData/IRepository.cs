using StaffManage.Model;
using StaffManage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManage.RepositoryData
{
    public interface IRepository
    {
        string CraeteStaff(StaffDetail staff);
        string CreateTask(TaskDetails task);
        string AssignedTask(AssignedtaskViewModel assignedTask);
        IEnumerable<TaskDetails> GetTasksWeekely();
        string UpdateTask(int taskId);
        double GetHoursWeekly();
        IEnumerable<StaffDetail> GetActiveStaff();
        IEnumerable<TaskDetails> GetActiveTask();
        double TaskRemainTime(int taskId);
    }
}
