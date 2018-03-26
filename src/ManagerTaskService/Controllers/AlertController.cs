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
                var checks = managerTaskDataAccess.GetChecksByManager(manager).ToList();
                var alerts = GetAlertsFromCheck(checks).ToList();
                return View(alerts);
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }

        public IEnumerable<DriverCheckAlert> GetAlertsFromCheck(List<Check> checks)
        {
            if (checks == null || checks.Count == 0)
            {
                yield return null;
            }
            else
            {
                foreach (var check in checks)
                {
                    if (!check.Success)
                    {
                        yield return new DriverCheckAlert(
                            check.Driver.Name, AlertType.CheckFailed, AlertLevel.Critical, DateTime.Now);
                    }
                    else if (check.Date - DateTime.Now <= ExpiringSpan && check.Date >= DateTime.Now)
                    {
                        yield return new DriverCheckAlert(
                            check.Driver.Name, AlertType.CheckExpiring, AlertLevel.Warning, DateTime.Now);
                    }
                    else if (check.Date < DateTime.Now || check.Type == (int)CheckType.PhotocardExpired)
                    {
                        yield return new DriverCheckAlert(
                            check.Driver.Name, AlertType.CheckExpired, AlertLevel.Error, DateTime.Now);
                    }
                }
            }
        }
    }
}