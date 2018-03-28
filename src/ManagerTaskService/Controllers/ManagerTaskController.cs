namespace ManagerTaskService.Controllers
{
    using ManagerTask.Data;
    using System;
    using System.Linq;
    using System.Web.Mvc;

    /// <summary>
    /// The manager task controller
    /// </summary>
    [Authorize]
    public class ManagerTaskController : Controller
    {
        private IManagerTaskDataAccess managerTaskDataAccess;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagerTaskController"/> class
        /// </summary>
        /// <param name="_managerTaskDataAccess">The manager task data access interface</param>
        public ManagerTaskController(IManagerTaskDataAccess _managerTaskDataAccess)
        {
            managerTaskDataAccess = _managerTaskDataAccess;
        }

        /// <summary>
        /// The index
        /// </summary>
        /// <returns>The index view result</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Adds the driver.
        /// </summary>
        /// <returns>The add driver action view result</returns>
        [HttpGet]
        public ActionResult AddDriver()
        {
            return this.View();
        }

        /// <summary>
        /// Adds the driver
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <param name="dateJoinedCompany">The date the dirver joined the company.</param>
        /// <returns>The redirect result</returns>
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

        /// <summary>
        /// Gets the driver
        /// </summary>
        /// <param name="name">The driver name.</param>
        /// <returns>The get dirver view result</returns>
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
                return View();
            }
        }

        /// <summary>
        /// Gets the drivers
        /// </summary>
        /// <returns>The get drivers view result</returns>
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

        /// <summary>
        /// Adds the check
        /// </summary>
        /// <returns>The add check view result</returns>
        [HttpGet]
        public ActionResult AddCheck()
        {
            return View();
        }


        /// <summary>
        /// Adds the check
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <param name="type">The check type.</param>
        /// <param name="success">The success flag.</param>
        /// <param name="date">The check time.</param>
        /// <returns>The add check view result</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
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
                }
            }

            return View();
        }

        /// <summary>
        /// Gets the checks by manager
        /// </summary>
        /// <returns>The check collection view result</returns>
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

        /// <summary>
        /// Gets the checks by driver
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <returns>The check collection view result</returns>
        [HttpGet]
        public ActionResult GetChecksByDriver(string driver)
        {
            try
            {
                var checks = managerTaskDataAccess.GetChecksByDriver(driver).ToList();
                return View(checks);
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }
    }
}