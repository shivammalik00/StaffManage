using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using StaffManage.Controllers;
using StaffManage.Model;
using StaffManage.Models;
using StaffManage.RepositoryData;
using System;
using System.Collections.Generic;

namespace StaffManagementTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void StaffManagementController_CraeteStaff()
        {
            var mockRepo = new Mock<IRepository>();
            var detail = new StaffDetail { Name = "Shivam", HoursAvailable = 8, DateCreated = DateTime.Now, IsAvailable = true };
            mockRepo.Setup(repo => repo.CraeteStaff(detail)).Returns("Added");
            var controller = new StaffManagementController(mockRepo.Object);

            var result1 = controller.CreateStaff(detail);
            var result = result1 as OkResult;
            Assert.AreEqual(result.StatusCode, 200);
        }
        [Test]
        public void StaffManagementController_CraeteTask()
        {
            var mockRepo = new Mock<IRepository>();
            var detail = new TaskDetails { Name = "Task1", DateCreated = DateTime.Now, Hour = 6, Iscompleted = false };
            mockRepo.Setup(repo => repo.CreateTask(detail)).Returns("Added");
            var controller = new StaffManagementController(mockRepo.Object);

            var result = controller.CreateTask(detail) as OkResult;

            Assert.AreEqual(result.StatusCode, 200);

        }
        [Test]
        public void StaffManagementController_AssignTask()
        {
            var mockRepo = new Mock<IRepository>();
            var detail = new AssignedtaskViewModel { TaskID = 1, StaffID = 1, AsiggnedHours = 4, AssignedDate = DateTime.Now };
            mockRepo.Setup(repo => repo.AssignedTask(detail)).Returns("Added");
            var controller = new StaffManagementController(mockRepo.Object);

            var result = controller.AssignTask(detail) as OkResult;


            Assert.AreEqual(result.StatusCode, 200);

        }
        [Test]
        public void StaffManagementController_GetWeeklyTasks()
        {
            var mockRepo = new Mock<IRepository>();
            var detail = new TaskDetails { Name = "Task1", DateCreated = DateTime.Now, Hour = 6, Iscompleted = false };
            mockRepo.Setup(repo => repo.GetTasksWeekely()).Returns(new List<TaskDetails> { detail });
            var controller = new StaffManagementController(mockRepo.Object);

            var result = controller.GetWeeklyTasks() as JsonResult;


            Assert.NotNull(result.Value);

        }
        [Test]
        public void StaffManagementController_GetWeeklyHours()
        {
            var mockRepo = new Mock<IRepository>();
            mockRepo.Setup(repo => repo.GetHoursWeekly()).Returns(5);
            var controller = new StaffManagementController(mockRepo.Object);

            var result = controller.GetWeeklyHours() as JsonResult;


            Assert.NotNull(result.Value);

        }
        [Test]
        public void StaffManagementController_UpdateTask()
        {
            var mockRepo = new Mock<IRepository>();
            mockRepo.Setup(repo => repo.UpdateTask(1)).Returns("Updated");
            var controller = new StaffManagementController(mockRepo.Object);

            var result = controller.UpdateTask(1) as OkResult;


            Assert.AreEqual(result.StatusCode, 200);

        }
        [Test]
        public void StaffManagementController_GetActiveStaffList()
        {
            var mockRepo = new Mock<IRepository>();
            var detail = new StaffDetail { Name = "Shivam", DateCreated = DateTime.Now, HoursAvailable = 8, IsAvailable = true };
            mockRepo.Setup(repo => repo.GetActiveStaff()).Returns(new List<StaffDetail> { detail });
            var controller = new StaffManagementController(mockRepo.Object);

            var result = controller.GetActiveStaffList() as JsonResult;


            Assert.NotNull(result.Value);

        }
        [Test]
        public void StaffManagementController_GetActiveTaskList()
        {
            var mockRepo = new Mock<IRepository>();
            var detail = new TaskDetails { Name = "Task1", DateCreated = DateTime.Now, Hour = 6, Iscompleted = false };

            mockRepo.Setup(repo => repo.GetActiveTask()).Returns(new List<TaskDetails> { detail });
            var controller = new StaffManagementController(mockRepo.Object);

            var result = controller.GetActiveTaskList() as JsonResult;


            Assert.NotNull(result.Value);

        }
        [Test]
        public void StaffManagementController_GetTaskRemainigTime()
        {
            var mockRepo = new Mock<IRepository>();


            mockRepo.Setup(repo => repo.TaskRemainTime(1)).Returns(4);
            var controller = new StaffManagementController(mockRepo.Object);

            var result = controller.GetTaskRemainigTime(1) as JsonResult;

            Assert.NotNull(result.Value);

        }
    }
}