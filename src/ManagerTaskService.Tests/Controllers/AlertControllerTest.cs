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
            Assert.AreEqual(alerts.Count, 2);

            var alert1 = alerts.FirstOrDefault();
            Assert.AreEqual(alert1.DriverName, "Driver1");
            Assert.AreEqual(alert1.Level, AlertLevel.Critical);
            Assert.AreEqual(alert1.Type, AlertType.CheckMissing);
        }
    }
}
