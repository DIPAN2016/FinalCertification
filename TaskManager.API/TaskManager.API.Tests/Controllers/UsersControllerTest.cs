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
    public class UsersControllerTest
    {
        [Test]
        public void GetTaskDetails()
        {
            // Arrange
            UsersModel record = new UsersModel()
            {
                FirstName = "John",
                LastName = "trump",
                EmployeeId = 321,
            };
            UsersController controller = new UsersController();

            // Act
            var result = controller.Post(record);
            controller = new UsersController();

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
            UsersModel record = new UsersModel() {
                FirstName="John",
                LastName="trump",
                EmployeeId=321,
            };
            UsersController controller = new UsersController();

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
            UsersModel record = new UsersModel()
            {
                FirstName = "John",
                LastName = "trump",
                EmployeeId = 321,
            };
            UsersController controller = new UsersController();

            // Act
            var result = controller.Post(record);

            int userID = 0;
            controller = new UsersController();
            var resultPut = controller.GetTaskDetails();
            userID = resultPut.ElementAt(0).UserId;
            record = new UsersModel()
            {
                UserId= userID,
                FirstName = "Donald",
                LastName = "Trump",
                EmployeeId = 321,
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
            UsersModel record = new UsersModel()
            {
                FirstName = "John",
                LastName = "trump",
                EmployeeId = 321,
            };
            UsersController controller = new UsersController();

            // Act
            var result = controller.Post(record);

            int userID = 0;
            var resultDelete = controller.GetTaskDetails();
            userID = resultDelete.ElementAt(0).UserId;

            // Act
            var success = controller.Delete(userID);

            // Assert
            Assert.IsNotNull(success);
            Assert.AreEqual(true, success);
        }
    }
}
