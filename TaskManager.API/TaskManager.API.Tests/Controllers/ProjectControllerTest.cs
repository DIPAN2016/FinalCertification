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
    public class ProjectControllerTest
    {
        [Test]
        public void GetTaskDetails()
        {
            // Arrange
            ProjectModel record = new ProjectModel()
            {
                ManagerId = 3211,
                Priority = 5,
                Projects = "Task Manager",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            };

            ProjectController controller = new ProjectController();

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
            ProjectModel record = new ProjectModel()
                { ManagerId= 3211,
            Priority= 5, Projects= "Task Manager", StartDate = DateTime.Now,EndDate= DateTime.Now};
            ProjectController controller = new ProjectController();

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
            ProjectModel record = new ProjectModel()
            {
                ManagerId = 3211,
                Priority = 5,
                Projects = "Task Manager",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            };
            ProjectController controller = new ProjectController();

            // Act
            var result = controller.Post(record);

            int projectId = 0;
            var resultPut = controller.GetTaskDetails();
            projectId = resultPut.ElementAt(0).ProjectId;
            record = new ProjectModel()
            {
                ProjectId = projectId,
                ManagerId = 3510,
                Priority = 4,
                Projects = "Task Manager1",
                StartDate = DateTime.Now.AddDays(10),
                EndDate = DateTime.Now.AddDays(10)
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
            ProjectModel record = new ProjectModel()
            {
                ManagerId = 3211,
                Priority = 5,
                Projects = "Task Manager",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            };
            ProjectController controller = new ProjectController();

            // Act
            var result = controller.Post(record);
            int projectId = 0;
            var resultDelete = controller.GetTaskDetails();
            projectId = resultDelete.ElementAt(0).ProjectId;

            // Act
            var success = controller.Delete(projectId);

            // Assert
            Assert.IsNotNull(success);
            Assert.AreEqual(true, success);
        }
    }
}
