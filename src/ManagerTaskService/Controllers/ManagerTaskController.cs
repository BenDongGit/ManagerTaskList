namespace ManagerTaskService.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using ManagerTask.Data;

    public class ManagerTaskController : Controller
    {
        private IManagerTaskDataAccess managerTaskDataAccess;

        public ManagerTaskController(IManagerTaskDataAccess _managerTaskDataAccess)
        {
            managerTaskDataAccess = _managerTaskDataAccess;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddManager()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddManager(Manager manager)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    managerTaskDataAccess.AddManager(manager.Name);
                    ViewBag.Success = string.Format("The manager {0} has been added", manager.Name);
                }
                catch (Exception e)
                {
                    ViewBag.Error = e.Message;
                    return View();
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult GetManager(string name)
        {
            try
            {
                var manager = managerTaskDataAccess.GetManager(name);
                return View(manager);
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View(default(Manager));
            }
        }

        [HttpGet]
        public ActionResult AddDriver()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDriver(string driver, string manager, DateTime? dateJoinedCompany)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    managerTaskDataAccess.AddDriver(driver, manager, dateJoinedCompany);
                    ViewBag.Success = string.Format("The driver {0} has been added", driver);
                }
                catch (Exception e)
                {
                    ViewBag.Error = e.Message;
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult GetDriver(string name)
        {
            try
            {
                var driver = managerTaskDataAccess.GetDriver(name);
                return View(driver);
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View(default(Driver));
            }
        }

        [HttpGet]
        public ActionResult AddCheck()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCheck(string driver, CheckType type, bool success, DateTime date)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    managerTaskDataAccess.AddCheck(driver, type, success, date);
                    return RedirectToAction("GetChecksByDriver", new { driver });
                }
                catch (Exception e)
                {
                    ViewBag.Error = e.Message;
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult GetChecksByManager(string manager)
        {
            var checks = managerTaskDataAccess.GetChecksByManager(manager).ToList();
            return View(checks);
        }

        [HttpGet]
        public ActionResult GetChecksByDriver(string driver)
        {
            var checks = managerTaskDataAccess.GetChecksByDriver(driver).ToList();
            return View(checks);
        }
    }
}