namespace ManagerTaskService.Tests.Controllers
{
    using FluentAssertions;
    using ManagerTask.Data;
    using ManagerTaskService.Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    [TestClass]
    public class ManagerTaskControllerTest
    {
        private Mock<MockTestDataAccess> mockManagerTaskDataAccess = new Mock<MockTestDataAccess>();

        [TestMethod]
        public void Test_Index()
        {
            ManagerTaskController mtc = new ManagerTaskController(mockManagerTaskDataAccess.Object);
            ViewResult result = mtc.Index() as ViewResult;

            mtc.Should().NotBeNull();
            result.Should().NotBeNull();
        }

        [TestMethod]
        public void Test_AddDriver()
        {
            ManagerTaskController mtc = new ManagerTaskController(mockManagerTaskDataAccess.Object);
            ViewResult result = mtc.AddDriver() as ViewResult;

            mtc.Should().NotBeNull();
            result.Should().NotBeNull();

            string driver = "Test Driver";
            result = mtc.AddDriver(driver, null) as ViewResult;

            result.Should().NotBeNull();
            Assert.AreEqual(result.ViewBag.Error, "Object reference not set to an instance of an object.");
        }


        [TestMethod]
        public void Test_GetDriver()
        {
            ManagerTaskController mtc = new ManagerTaskController(mockManagerTaskDataAccess.Object);
            string driverName = "Test Manager";
            ViewResult result = mtc.GetDriver(driverName) as ViewResult;
            var driver = result.Model as Driver;

            mtc.Should().NotBeNull();
            result.Should().NotBeNull();
            Assert.AreEqual(driver.Name, driverName);
        }

        [TestMethod]
        public void Test_AddCheck()
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

        [TestMethod]
        public void Test_GetChecksByManager()
        {
            ManagerTaskController mtc = new ManagerTaskController(mockManagerTaskDataAccess.Object);
            ViewResult result = mtc.GetChecksByManager() as ViewResult;

            mtc.Should().NotBeNull();
            result.Should().NotBeNull();
            Assert.AreEqual(result.ViewBag.Error, "Object reference not set to an instance of an object.");
        }
    }
}
