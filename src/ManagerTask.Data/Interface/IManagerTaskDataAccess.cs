namespace ManagerTask.Data
{
    using System;
    using System.Collections.Generic;

    public interface IManagerTaskDataAccess
    {
        void AddDriver(string name, string managerName, DateTime? dateJoinedCompany);

        Driver GetDriver(string name);

        IEnumerable<Driver> GetDrivers(string manager);

        IEnumerable<Driver> GetDriversWithNoChecks(string manager);

        void AddCheck(string driver, CheckType type, bool success, DateTime date);

        void AddChecks(IEnumerable<Check> checks);

        IEnumerable<Check> GetChecksByManager(string manager);

        IEnumerable<Check> GetChecksByDriver(string driver);
    }
}
