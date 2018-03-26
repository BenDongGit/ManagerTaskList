namespace ManagerTaskService.Models
{
    using System;

    /// <summary>
    /// Model class for an alert on a driver check
    /// </summary>
    public class DriverCheckAlert
    {
        public string DriverName { get; private set; }

        public AlertType Type { get; private set; }

        public DateTime Date { get; private set; }

        public AlertLevel Level { get; private set; }

        public DriverCheckAlert(
            string driverName,
            AlertType type,
            AlertLevel level,
            DateTime date)
        {
            DriverName = driverName;
            Type = type;
            Level = level;
            Date = date;
        }
    }
}