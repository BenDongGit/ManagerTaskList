namespace ManagerTaskService.Models
{
    using System;

    /// <summary>
    /// Model class for an alert on a driver check
    /// </summary>
    public class DriverCheckAlert
    {
        /// <summary>
        /// Gets the driver name
        /// </summary>
        public string DriverName { get; private set; }

        /// <summary>
        /// Gets the alert type
        /// </summary>
        public AlertType Type { get; private set; }

        /// <summary>
        /// Gets the date
        /// </summary>
        public DateTime Date { get; private set; }

        /// <summary>
        /// Gets the alert level
        /// </summary>
        public AlertLevel Level { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DriverCheckAlert"/> class
        /// </summary>
        /// <param name="driverName">The driver name</param>
        /// <param name="type">The alert type</param>
        /// <param name="level">The alert level</param>
        /// <param name="date">The alert date</param>
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