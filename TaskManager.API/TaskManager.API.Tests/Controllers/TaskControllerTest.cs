using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.API.Controllers;
using TaskManager.Model;

namespace TaskManager.API.Tests
{
    [TestFixture]
    public class TaskControllerTest
    {
        [Test]
        public void GetTaskDetails()
        {
            // Arrange
            TaskModel record = new TaskModel()
            {
                Task = "Current Task",
                ParentTask = "Parent Task",
                Project = "Project Manager",
                Priority = 2,
                Status = "Completed",
                User = "ABC",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            };

            TaskController controller = new TaskController();


            var result = controller.Post(record);

            // Act
            var resultGet = controller.GetTaskDetails();

            // Assert
            Assert.IsNotNull(resultGet);
            Assert.Greater(resultGet.Count(), 0);
        }

        [Test]
        public void Post()
        {
            // Arrange
            TaskModel record = new TaskModel()
            { Task ="Current Task",
              ParentTask ="Parent Task",
              Project ="Project Manager",
              Priority= 2,
              Status ="Completed",
              User ="ABC",
              StartDate =DateTime.Now,
              EndDate =DateTime.Now
            };
            TaskController controller = new TaskController();

            // Act
            var result = controller.Post(record);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void Put()
        {
            // Arrange
            TaskModel record = new TaskModel()
            {
                Task = "Current Task",
                ParentTask = "Parent Task",
                Project = "Project Manager",
                Priority = 2,
                Status = "Completed",
                User = "ABC",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            };

            TaskController controller = new TaskController();


            var result = controller.Post(record);
            int taskID = 0;
            var resultPut = controller.GetTaskDetails();
            taskID = resultPut.ElementAt(0).TaskId;
            record = new TaskModel()
            {
                TaskId = taskID,
                Task = "Current Task 2",
                ParentTask = "Parent Task 2",
                Project = "Project Manager 2",
                Priority = 2,
                Status = "Completed",
                User = "ABC",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            };
            

            // Act
            var success = controller.Put(record);

            // Assert
            Assert.IsNotNull(success);
            Assert.AreEqual(true, success);
        }

        [Test]
        public void Delete()
        {
            // Arrange
            TaskModel record = new TaskModel()
            {
                Task = "Current Task",
                ParentTask = "Parent Task",
                Project = "Project Manager",
                Priority = 2,
                Status = "Completed",
                User = "ABC",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            };

            TaskController controller = new TaskController();

            
            var result = controller.Post(record);
            int taskID = 0;
            var resultDelete = controller.GetTaskDetails();
            taskID = resultDelete.ElementAt(0).TaskId;

            // Act
            var success = controller.Delete(taskID);

            // Assert
            Assert.IsNotNull(success);
            Assert.AreEqual(true, success);
        }
    }
}
