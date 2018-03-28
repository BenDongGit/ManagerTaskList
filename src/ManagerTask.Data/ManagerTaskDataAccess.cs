namespace ManagerTask.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Helper;

    /// <summary>
    /// The manager task data access
    /// </summary>
    public class ManagerTaskDataAccess : IManagerTaskDataAccess
    {
        private IDbContextHelper<ManagerTaskContext> databaseHelper = new DbContextHelper<ManagerTaskContext>();

        /// <summary>
        /// Adds the driver.
        /// </summary>
        /// <param name="name">The driver name.</param>
        /// <param name="managerName">The manager name.</param>
        /// <param name="dateJoinedCompany">The date the driver joined company.</param>
        public void AddDriver(string name, string managerName, DateTime? dateJoinedCompany)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(managerName))
            {
                throw new InvalidOperationException("Missing manager name or dirver name");
            }

            databaseHelper.CallWithTransaction(context =>
            {
                var manager = context.Users.FirstOrDefault(
                    m => m.UserName.ToLower() == managerName.ToLower());
                if (manager == null)
                {
                    throw new InvalidOperationException("The manager does not exist");
                }

                var driver = context.Drivers.FirstOrDefault(
                    d => d.Name.ToLower() == name.ToLower());
                if (driver != null)
                {
                    throw new InvalidOperationException("The driver has been added before");
                }

                driver = new Driver
                {
                    Name = name,
                    Manager = manager,
                    DateJoinedCompany = dateJoinedCompany
                };

                context.Set<Driver>().Add(driver);
                context.SaveChanges();
            });
        }

        /// <summary>
        /// Gets the driver.
        /// </summary>
        /// <param name="name">The driver name.</param>
        /// <returns>The driver</returns>
        public Driver GetDriver(string name)
        {
            return databaseHelper.Call(context =>
            {
                return context.Drivers.FirstOrDefault(m => m.Name.ToLower() == name.ToLower());
            });
        }

        /// <summary>
        /// Gets the drivers.
        /// </summary>
        /// <param name="manager">The manager.</param>
        /// <returns>Driver collection</returns>
        public IEnumerable<Driver> GetDrivers(string managerName)
        {
            return databaseHelper.CallWithTransaction(context =>
            {
                var manager = context.Users.FirstOrDefault(
                   m => m.UserName.ToLower() == managerName.ToLower());

                if (manager == null)
                {
                    return null;
                }

                return manager.Drivers.ToList();
            });
        }

        /// <summary>
        /// Gets the drivers with no checks.
        /// </summary>
        /// <param name="manager">The manager.</param>
        /// <returns>Driver collection</returns>
        public IEnumerable<Driver> GetDriversWithNoChecks(string managerName)
        {
            return databaseHelper.CallWithTransaction(context =>
            {
                var manager = context.Users.FirstOrDefault(
                   m => m.UserName.ToLower() == managerName.ToLower());

                if (manager == null)
                {
                    return null;
                }

                return manager.Drivers.Where(d => !d.Checks.Any()).ToList();
            });
        }

        /// <summary>
        /// Adds the check.
        /// </summary>
        /// <param name="driver">The driver name.</param>
        /// <param name="type">The check type.</param>
        /// <param name="success">The success flag.</param>
        /// <param name="date">The check time.</param>
        public void AddCheck(string driverName, CheckType type, bool success, DateTime date)
        {
            if (string.IsNullOrEmpty(driverName))
            {
                throw new InvalidOperationException("The dirver should not be empty");
            }

            databaseHelper.CallWithTransaction(context =>
            {
                var driver = context.Drivers.FirstOrDefault(
                    d => d.Name.ToLower() == driverName.ToLower());

                if (driver == null)
                {
                    throw new InvalidOperationException("The driver is not found");
                }

                Check check = new Check
                {
                    Driver = driver,
                    Success = success,
                    Date = DateTime.Now,
                    Type = (int)type
                };

                context.Set<Check>().Add(check);
                context.SaveChanges();
            });
        }

        /// <summary>
        /// Adds the checks.
        /// </summary>
        /// <param name="checks">The check collection.</param>
        public void AddChecks(IEnumerable<Check> checks)
        {
            if (checks == null || checks.Count() == 0)
            {
                throw new InvalidOperationException("There is no available check to be added");
            }

            databaseHelper.CallWithTransaction(context =>
            {
                context.Set<Check>().AddRange(checks);
                context.SaveChanges();
            });
        }

        /// <summary>
        /// Gets the checks by manager.
        /// </summary>
        /// <param name="manager">The manager.</param>
        /// <returns>The check collection</returns>
        public IEnumerable<Check> GetChecksByManager(string managerName)
        {
            if (string.IsNullOrEmpty(managerName))
            {
                throw new InvalidOperationException("The manager should not be empty");
            }

            return databaseHelper.Call<IEnumerable<Check>>(context =>
            {
                var manager = context.Users.FirstOrDefault(
                    m => m.UserName.ToLower() == managerName.ToLower());
                if (manager == null)
                {
                    return null;
                }

                return manager.Drivers.SelectMany(d => d.Checks).ToList();
            });
        }

        /// <summary>
        /// Gets the checks by driver.
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <returns>The check collection</returns>
        public IEnumerable<Check> GetChecksByDriver(string driverName)
        {
            if (string.IsNullOrEmpty(driverName))
            {
                throw new InvalidOperationException("The driver name should not be empty");
            }

            return databaseHelper.Call<IEnumerable<Check>>(context =>
            {
                var driver = context.Drivers.FirstOrDefault(
                    d => d.Name.ToLower() == driverName.ToLower());
                if (driver == null)
                {
                    return null;
                }

                return driver.Checks.ToList();
            });
        }
    }
}
