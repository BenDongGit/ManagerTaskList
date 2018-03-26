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
        public void Test_AddManager()
        {
            ManagerTaskController mtc = new ManagerTaskController(mockManagerTaskDataAccess.Object);
            ViewResult result = mtc.AddManager() as ViewResult;

            mtc.Should().NotBeNull();
            result.Should().NotBeNull();

            Mock<Manager> mockManager = new Mock<Manager>();
            mockManager.Object.Name = "Test Name";
            result = mtc.AddManager(mockManager.Object) as ViewResult;

            result.Should().NotBeNull();
            Assert.AreEqual(result.ViewBag.Success, string.Format("The manager {0} has been added", mockManager.Object.Name));
        }

        [TestMethod]
        public void Test_GetManager()
        {
            ManagerTaskController mtc = new ManagerTaskController(mockManagerTaskDataAccess.Object);
            string managerName = "Test Manager";
            ViewResult result = mtc.GetManager(managerName) as ViewResult;
            var manager = result.Model as Manager;

            mtc.Should().NotBeNull();
            result.Should().NotBeNull();
            Assert.AreEqual(manager.Name, managerName);
        }

        [TestMethod]
        public void Test_AddDriver()
        {
            ManagerTaskController mtc = new ManagerTaskController(mockManagerTaskDataAccess.Object);
            ViewResult result = mtc.AddDriver() as ViewResult;

            mtc.Should().NotBeNull();
            result.Should().NotBeNull();

            string driver = "Test Driver";
            string manager = "Test Manager";
            result = mtc.AddDriver(driver, manager, null) as ViewResult;

            result.Should().NotBeNull();
            Assert.AreEqual(result.ViewBag.Success, string.Format("The driver {0} has been added", driver));
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
            string manager = "Test Manger";
            ViewResult result = mtc.GetChecksByManager(manager) as ViewResult;
            var checks = (result.Model as IEnumerable<Check>).ToList();

            mtc.Should().NotBeNull();
            result.Should().NotBeNull();
            Assert.AreEqual(checks.Count, 2);
            Assert.AreEqual(checks.FirstOrDefault().Driver.Manager.Name, manager);
        }
    }
}
