using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FitnessApp.BL.Models;
using System.Linq;

namespace FitnessApp.BL.Controllers.Tests
{
    [TestClass()]
    public class EatingControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            // Arange
            var userName = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var eatingController = new EatingController(userController.CurrentUser);
            var food = new Food(foodName, rnd.Next(50, 500), rnd.Next(50, 500),
                    rnd.Next(50, 500), rnd.Next(50, 500));

            // Act
            eatingController.Add(food, 100);

            // Assert
            Assert.AreEqual(food.Name, eatingController.Eating.Foods.First().Key.Name);
        }
    }
}