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
            AlertController serviceController = new AlertController(mockManagerTaskDataAccess.Object);
            string manager = "Test Manager";
            ViewResult result = serviceController.GetAlerts(manager) as ViewResult;
            List<DriverCheckAlert> alerts = result.Model as List<DriverCheckAlert>;

            serviceController.Should().NotBeNull();
            result.Should().NotBeNull();
            Assert.AreEqual(alerts.Count, 2);

            var firstAlert = alerts.FirstOrDefault();
            Assert.AreEqual(firstAlert.DriverName, "Driver1");
            Assert.AreEqual(firstAlert.Level, AlertLevel.Warning);
            Assert.AreEqual(firstAlert.Type, AlertType.CheckExpiring);

            var secondAlert = alerts.FirstOrDefault(a => a.DriverName == "Driver2");
            Assert.AreEqual(secondAlert.DriverName, "Driver2");
            Assert.AreEqual(secondAlert.Level, AlertLevel.Critical);
            Assert.AreEqual(secondAlert.Type, AlertType.CheckFailed);
        }
    }
}
