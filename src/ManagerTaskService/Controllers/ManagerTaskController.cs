namespace ManagerTaskService.Controllers
{
    using ManagerTask.Data;
    using System;
    using System.Linq;
    using System.Web.Mvc;

    [Authorize]
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
        public ActionResult AddDriver()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDriver(string driver, DateTime? dateJoinedCompany)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = HttpContext.User;
                    if (user == null)
                    {
                        ViewBag.Error = "There is no manager found";
                        return View();
                    }

                    managerTaskDataAccess.AddDriver(driver, user.Identity.Name, dateJoinedCompany);
                    return RedirectToAction("GetDrivers");
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
        public ActionResult GetDrivers()
        {
            try
            {
                var userName = HttpContext.User.Identity.Name;
                var drivers = managerTaskDataAccess.GetDrivers(userName).ToList();
                return View(drivers);
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
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
        public ActionResult GetChecksByManager()
        {
            try
            {
                var userName = HttpContext.User.Identity.Name;
                var checks = managerTaskDataAccess.GetChecksByManager(userName).ToList();
                return View(checks);
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }

        [HttpGet]
        public ActionResult GetChecksByDriver(string driver)
        {
            var checks = managerTaskDataAccess.GetChecksByDriver(driver).ToList();
            return View(checks);
        }
    }
}