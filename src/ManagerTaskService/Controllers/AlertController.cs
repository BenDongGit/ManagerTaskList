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

        [HttpGet]
        public ActionResult GetAlerts(string manager)
        {
            try
            {
                var checks = managerTaskDataAccess.GetChecksByManager(manager).ToList();
                var alerts = GetAlertsWithChecks(checks).ToList();
                return View(alerts);
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }

        private IEnumerable<DriverCheckAlert> GetAlertsWithChecks(List<Check> checks)
        {
            var alerts = new List<DriverCheckAlert>();
            if (checks == null || checks.Count == 0)
            {
                return alerts;
            }
            else
            {
                var checkGroups = checks.GroupBy(c => c.Driver);
                foreach (var checkCollection in checkGroups)
                {
                    var checkTypes = new List<int>();
                    foreach (var check in checkCollection)
                    {
                        if (!checkTypes.Contains(check.Type))
                        {
                            checkTypes.Add(check.Type);
                        }
                    }

                    if (checkTypes.Count < Enum.GetValues(typeof(CheckType)).Length)
                    {
                        alerts.Add(new DriverCheckAlert(checkCollection.Key.Name, AlertType.CheckMissing, AlertLevel.Critical, DateTime.Now));
                    }
                    else
                    {
                        if (checkCollection.Any(c => !c.Success))
                        {
                            alerts.Add(new DriverCheckAlert(checkCollection.Key.Name, AlertType.CheckFailed, AlertLevel.Critical, DateTime.Now));
                        }
                        else if (checkCollection.Any(c => c.Date - DateTime.Now <= ExpiringSpan && c.Date >= DateTime.Now))
                        {
                            alerts.Add(new DriverCheckAlert(checkCollection.Key.Name, AlertType.CheckExpiring, AlertLevel.Warning, DateTime.Now));
                        }
                        else
                        {
                            if (checkCollection.Any(c => c.Date < DateTime.Now))
                            {
                                alerts.Add(new DriverCheckAlert(checkCollection.Key.Name, AlertType.CheckExpired, AlertLevel.Error, DateTime.Now));
                            }
                        }
                    }
                }
            }

            return alerts;
        }
    }
}