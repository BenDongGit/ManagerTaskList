namespace ManagerTaskService.Tests.Controllers
{
    using FluentAssertions;
    using ManagerTask.Data;
    using ManagerTaskService.Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System;
    using System.Web.Mvc;

    /// <summary>
    /// The manager task controller test
    /// </summary>
    [TestClass]
    public class ManagerTaskControllerTest
    {
        private Mock<FakeManagerTaskDataAccess> mockManagerTaskDataAccess = new Mock<FakeManagerTaskDataAccess>();

        /// <summary>
        /// Tests the index
        /// </summary>
        [TestMethod]
        public void Index()
        {
            ManagerTaskController mtc = new ManagerTaskController(mockManagerTaskDataAccess.Object);
            ViewResult result = mtc.Index() as ViewResult;

            mtc.Should().NotBeNull();
            result.Should().NotBeNull();
        }

        /// <summary>
        /// Tests the add driver
        /// </summary>
        [TestMethod]
        public void AddDriver()
        {
            ManagerTaskController mtc = new ManagerTaskController(mockManagerTaskDataAccess.Object);
            ViewResult result = mtc.AddDriver() as ViewResult;

            mtc.Should().NotBeNull();
            result.Should().NotBeNull();

            string driver = "Test Driver";
            result = mtc.AddDriver(driver, null) as ViewResult;

            result.Should().NotBeNull();
        }

        /// <summary>
        /// Tests the get driver
        /// </summary>
        [TestMethod]
        public void GetDriver()
        {
            ManagerTaskController mtc = new ManagerTaskController(mockManagerTaskDataAccess.Object);
            string driverName = "Test Manager";
            ViewResult result = mtc.GetDriver(driverName) as ViewResult;
            var driver = result.Model as Driver;

            mtc.Should().NotBeNull();
            result.Should().NotBeNull();
            Assert.AreEqual(driver.Name, driverName);
        }

        /// <summary>
        /// Tests the add check
        /// </summary>
        [TestMethod]
        public void AddCheck()
        {
            ManagerTaskController mtc = new ManagerTaskController(mockManagerTaskDataAccess.Object);
            ViewResult result = mtc.AddCheck() as ViewResult;

            mtc.Should().NotBeNull();
            result.Should().NotBeNull();

            string driver = "Test Driver";
            CheckType checkType = CheckType.License;
            bool success = true;
            DateTime date = DateTime.Now;
            var redirectResult = mtc.AddCheck(driver, checkType, success, date) as RedirectToRouteResult;

            redirectResult.Should().NotBeNull();
            Assert.AreNotEqual(redirectResult.RouteName, "GetChecksByDriver");
        }

        /// <summary>
        /// Tests get checks by manager
        /// </summary>
        [TestMethod]
        public void GetChecksByManager()
        {
            ManagerTaskController mtc = new ManagerTaskController(mockManagerTaskDataAccess.Object);
            ViewResult result = mtc.GetChecksByManager() as ViewResult;

            mtc.Should().NotBeNull();
            result.Should().NotBeNull();
        }
    }
}
