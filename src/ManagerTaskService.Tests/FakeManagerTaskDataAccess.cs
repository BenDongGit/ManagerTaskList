namespace ManagerTaskService.Tests
{
    using System;
    using System.Collections.Generic;
    using ManagerTask.Data;

    /// <summary>
    /// The fake manager task data access
    /// </summary>
    public class FakeManagerTaskDataAccess : IManagerTaskDataAccess
    {
        /// <summary>
        /// Adds the driver.
        /// </summary>
        /// <param name="name">The driver name.</param>
        /// <param name="managerName">The manager name.</param>
        /// <param name="dateJoinedCompany">The date the driver joined company.</param>
        public void AddDriver(string name, string managerName, DateTime? dateJoinedCompany)
        {
            // To Do
        }

        /// <summary>
        /// Gets the driver.
        /// </summary>
        /// <param name="name">The driver name.</param>
        /// <returns>The driver</returns>
        public Driver GetDriver(string name)
        {
            return new Driver
            {
                Name = name
            };
        }

        /// <summary>
        /// Gets the drivers.
        /// </summary>
        /// <param name="manager">The manager.</param>
        /// <returns>Driver collection</returns>
        public IEnumerable<Driver> GetDrivers(string manager)
        {
            List<Driver> drivers = new List<Driver>
            {
                new Driver
                {
                   Name = "Test Driver",
                   Manager = new Manager
                   {
                       UserName = manager
                   },
                   Checks = new List<Check>
                   {
                       new Check
                       {
                           Date = DateTime.Now.AddDays(14),
                           Type = (int)CheckType.License,
                           Success = true
                        },
                        new Check
                        {
                            Date = DateTime.Now,
                            Type = (int)CheckType.PhotocardExpired,
                            Success = false
                        }
                   }
               }
            };

            return drivers;
        }

        /// <summary>
        /// Gets the drivers with no checks.
        /// </summary>
        /// <param name="manager">The manager.</param>
        /// <returns>Driver collection</returns>
        public IEnumerable<Driver> GetDriversWithNoChecks(string manager)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds the check.
        /// </summary>
        /// <param name="driver">The driver name.</param>
        /// <param name="type">The check type.</param>
        /// <param name="success">The success flag.</param>
        /// <param name="date">The check time.</param>

        public void AddCheck(string driver, CheckType type, bool success, DateTime date)
        {
            // To Do
        }

        /// <summary>
        /// Adds the checks.
        /// </summary>
        /// <param name="checks">The check collection.</param>
        public void AddChecks(IEnumerable<Check> checks)
        {
            // To Do
        }

        /// <summary>
        /// Gets the checks by manager.
        /// </summary>
        /// <param name="manager">The manager.</param>
        /// <returns>The check collection</returns>
        public IEnumerable<Check> GetChecksByManager(string managerName)
        {
            Driver driver1 = new Driver
            {
                Name = "Driver1",
                Manager = new Manager
                {
                    UserName = managerName
                }
            };

            Driver driver2 = new Driver
            {
                Name = "Driver2",
                Manager = new Manager
                {
                    UserName = managerName
                }
            };

            return new List<Check>
            {
                new Check
                {
                    Date = DateTime.Now.AddDays(14),
                    Driver = driver1,
                    Type = (int)CheckType.License,
                    Success = true
                },
                new Check
                {
                    Date = DateTime.Now,
                    Driver = driver2,
                    Type = (int)CheckType.PhotocardExpired,
                    Success = false
                }
            };
        }

        /// <summary>
        /// Gets the checks by driver.
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <returns>The check collection</returns>
        public IEnumerable<Check> GetChecksByDriver(string driver)
        {
            throw new NotImplementedException();
        }
    }
}
