namespace ManagerTaskService.Tests.Controllers
{
    using FluentAssertions;
    using ManagerTaskService.Controllers;
    using ManagerTaskService.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System.Collections.Generic;
    using System.Web.Mvc;

    [TestClass]
    public class AlertControllerTest
    {
        private Mock<MockTestDataAccess> mockManagerTaskDataAccess = new Mock<MockTestDataAccess>();

        [TestMethod]
        public void Test_GetAlerts()
        {
            AlertController alertController = new AlertController(mockManagerTaskDataAccess.Object);
            ViewResult result = alertController.GetAlerts() as ViewResult;
            List<DriverCheckAlert> alerts = result.Model as List<DriverCheckAlert>;

            alertController.Should().NotBeNull();
            result.Should().NotBeNull();
            alerts.Should().BeNull();
        }
    }
}
