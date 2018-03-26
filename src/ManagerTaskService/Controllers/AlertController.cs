namespace ManagerTaskService.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using ManagerTask.Data;
    using Models;

    public class AlertController : Controller
    {
        // Assume the exipring time span are 15 day
        private static readonly TimeSpan ExpiringSpan = TimeSpan.FromDays(15);
        private IManagerTaskDataAccess managerTaskDataAccess;

        public AlertController(IManagerTaskDataAccess _managerTaskDataAccess)
        {
            managerTaskDataAccess = _managerTaskDataAccess;
        }

        public ActionResult GetAlerts(string manager)
        {
            try
            {
                var drivers = managerTaskDataAccess.GetDrivers(manager).ToList();
                var alerts = GetAlerts(drivers).ToList();
                return View(alerts);
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }

        public IEnumerable<DriverCheckAlert> GetAlerts(List<Driver> drivers)
        {
            var alerts = new List<DriverCheckAlert>();
            if (drivers == null || drivers.Count == 0)
            {
                return alerts;
            }
            else
            {
                foreach (var driver in drivers)
                {
                    var checkTypes = new List<int>();
                    foreach (var check in driver.Checks)
                    {
                        if (!checkTypes.Contains(check.Type))
                        {
                            checkTypes.Add(check.Type);
                        }
                    }

                    if (checkTypes.Count < Enum.GetValues(typeof(CheckType)).Length)
                    {
                        alerts.Add(new DriverCheckAlert(driver.Name, AlertType.CheckMissing, AlertLevel.Critical, DateTime.Now));
                    }
                    else
                    {
                        if (driver.Checks.Any(c => !c.Success))
                        {
                            alerts.Add(new DriverCheckAlert(driver.Name, AlertType.CheckFailed, AlertLevel.Critical, DateTime.Now));
                        }
                        else if (driver.Checks.Any(c => c.Date - DateTime.Now <= ExpiringSpan && c.Date >= DateTime.Now))
                        {
                            alerts.Add(new DriverCheckAlert(driver.Name, AlertType.CheckExpiring, AlertLevel.Warning, DateTime.Now));
                        }
                        else
                        {
                            if (driver.Checks.Any(c => c.Date < DateTime.Now))
                            {
                                alerts.Add(new DriverCheckAlert(driver.Name, AlertType.CheckExpired, AlertLevel.Error, DateTime.Now));
                            }
                        }
                    }
                }
            }

            return alerts;
        }
    }
}