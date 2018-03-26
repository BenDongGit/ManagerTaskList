namespace ManagerTaskService.Tests
{
    using System;
    using System.Collections.Generic;
    using ManagerTask.Data;

    public class MockTestDataAccess : IManagerTaskDataAccess
    {
        public void AddCheck(string driver, CheckType type, bool success, DateTime date)
        {
            // To Do
        }

        public void AddChecks(IEnumerable<Check> checks)
        {
            // To Do
        }

        public void AddDriver(string name, string managerName, DateTime? dateJoinedCompany)
        {
            // To Do
        }

        public void AddManager(string name)
        {
            // To Do
        }

        public IEnumerable<Check> GetChecksByDriver(string driver)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Check> GetChecksByManager(string manager)
        {
            Driver driver1 = new Driver
            {
                Name = "Driver1",
                Manager = new Manager
                {
                    Name = manager
                }
            };

            Driver driver2 = new Driver
            {
                Name = "Driver2",
                Manager = new Manager
                {
                    Name = manager
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

        public Driver GetDriver(string name)
        {
            return new Driver
            {
                Name = name
            };
        }

        public IEnumerable<DriverCheck> GetDriverCheck()
        {
            throw new NotImplementedException();
        }

        public Manager GetManager(string name)
        {
            return new Manager
            {
                Name = name,
                Drivers = new List<Driver>
                {
                    new Driver
                    {
                        Name = "Test Driver",
                        DateJoinedCompany = DateTime.Now
                    }
                }
            };
        }
    }
}
