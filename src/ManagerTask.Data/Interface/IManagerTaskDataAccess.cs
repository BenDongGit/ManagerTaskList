namespace ManagerTask.Data
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The manager task data access interface
    /// </summary>
    public interface IManagerTaskDataAccess
    {
        /// <summary>
        /// Adds the driver.
        /// </summary>
        /// <param name="name">The driver name.</param>
        /// <param name="managerName">The manager name.</param>
        /// <param name="dateJoinedCompany">The date the driver joined company.</param>
        void AddDriver(string name, string managerName, DateTime? dateJoinedCompany);

        /// <summary>
        /// Gets the driver.
        /// </summary>
        /// <param name="name">The driver name.</param>
        /// <returns>The driver</returns>
        Driver GetDriver(string name);

        /// <summary>
        /// Gets the drivers.
        /// </summary>
        /// <param name="manager">The manager.</param>
        /// <returns>Driver collection</returns>
        IEnumerable<Driver> GetDrivers(string manager);

        /// <summary>
        /// Gets the drivers with no checks.
        /// </summary>
        /// <param name="manager">The manager.</param>
        /// <returns>Driver collection</returns>
        IEnumerable<Driver> GetDriversWithNoChecks(string manager);

        /// <summary>
        /// Adds the check.
        /// </summary>
        /// <param name="driver">The driver name.</param>
        /// <param name="type">The check type.</param>
        /// <param name="success">The success flag.</param>
        /// <param name="date">The check time.</param>
        void AddCheck(string driver, CheckType type, bool success, DateTime date);

        /// <summary>
        /// Adds the checks.
        /// </summary>
        /// <param name="checks">The check collection.</param>
        void AddChecks(IEnumerable<Check> checks);

        /// <summary>
        /// Gets the checks by manager.
        /// </summary>
        /// <param name="manager">The manager.</param>
        /// <returns>The check collection</returns>
        IEnumerable<Check> GetChecksByManager(string manager);

        /// <summary>
        /// Gets the checks by driver.
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <returns>The check collection</returns>
        IEnumerable<Check> GetChecksByDriver(string driver);
    }
}
