namespace ManagerTaskService.Tests.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ManagerTaskService.Controllers;
    using Moq;
    using ManagerTask.Data;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Web.Mvc;
    using ManagerTaskService.Models;

    [TestClass]
    public class AlertControllerTest
    {
        private Mock<MockTestDataAccess> mockManagerTaskDataAccess = new Mock<MockTestDataAccess>();

        [TestMethod]
        public void Test_GetAlerts()
        {
            AlertController alertController = new AlertController(mockManagerTaskDataAccess.Object);
            string manager = "Test Manager";
            ViewResult result = alertController.GetAlerts(manager) as ViewResult;
            List<DriverCheckAlert> alerts = result.Model as List<DriverCheckAlert>;

            alertController.Should().NotBeNull();
            result.Should().NotBeNull();
            Assert.AreEqual(alerts.Count, 1);

            var alert = alerts.FirstOrDefault();
            Assert.AreEqual(alert.DriverName, "Test Driver");
            Assert.AreEqual(alert.Level, AlertLevel.Critical);
            Assert.AreEqual(alert.Type, AlertType.CheckMissing);
        }
    }
}
