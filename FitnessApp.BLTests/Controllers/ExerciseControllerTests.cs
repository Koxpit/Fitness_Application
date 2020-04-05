using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitnessApp.BL.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using FitnessApp.BL.Models;
using System.Linq;

namespace FitnessApp.BL.Controllers.Tests
{
    [TestClass()]
    public class ExerciseControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            // Arange
            var userName = Guid.NewGuid().ToString();
            var activityName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            var activity = new Activity(activityName, rnd.Next(10, 50));

            // Act
            exerciseController.Add(activity, DateTime.Now, DateTime.Now.AddHours(1.0));

            // Assert
            Assert.AreNotEqual(activity.Name, exerciseController.Activities.First().Name);
        }
    }
}