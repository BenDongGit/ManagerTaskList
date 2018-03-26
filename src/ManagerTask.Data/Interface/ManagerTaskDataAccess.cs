namespace ManagerTask.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Helper;

    public class ManagerTaskDataAccess : IManagerTaskDataAccess
    {
        private IDbContextHelper<ManagerTaskContext> mtcHelper = new DbContextHelper<ManagerTaskContext>();

        public void AddManager(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Missing manager name");
            }

            mtcHelper.CallWithTransaction(context =>
            {
                if (context.Managers.ToList().FirstOrDefault(
                    m => m.Name.ToLower() == name.ToLower()) != null)
                {
                    throw new InvalidOperationException("The manager has already been added");
                }

                Manager manager = new Manager
                {
                    Name = name
                };
                context.Set<Manager>().Add(manager);
                context.SaveChanges();
            });
        }

        public Manager GetManager(string name)
        {
            return mtcHelper.Call(context =>
            {
                return context.Managers.FirstOrDefault(
                    m => m.Name.ToLower() == name.ToLower());
            });
        }

        public void AddDriver(string name, string managerName, DateTime? dateJoinedCompany)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(managerName))
            {
                throw new ArgumentNullException("Missing manager name or dirver name");
            }

            mtcHelper.CallWithTransaction(context =>
            {
                var manager = context.Managers.FirstOrDefault(
                    m => m.Name.ToLower() == managerName.ToLower());
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

        public Driver GetDriver(string name)
        {
            return mtcHelper.Call(context =>
            {
                return context.Drivers.FirstOrDefault(m => m.Name.ToLower() == name.ToLower());
            });
        }

        public void AddCheck(string driverName, CheckType type, bool success, DateTime date)
        {
            if (string.IsNullOrEmpty(driverName))
            {
                throw new ArgumentNullException("The dirver should not be empty");
            }

            mtcHelper.CallWithTransaction(context =>
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

        public void AddChecks(IEnumerable<Check> checks)
        {
            if (checks == null || checks.Count() == 0)
            {
                throw new ArgumentNullException("There is no available check to be added");
            }

            mtcHelper.CallWithTransaction(context =>
            {
                context.Set<Check>().AddRange(checks);
                context.SaveChanges();
            });
        }

        public IEnumerable<Check> GetChecksByManager(string managerName)
        {
            if (string.IsNullOrEmpty(managerName))
            {
                throw new ArgumentNullException("The manager should not be empty");
            }

            return mtcHelper.Call<IEnumerable<Check>>(context =>
            {
                var manager = context.Managers.FirstOrDefault(
                    m => m.Name.ToLower() == managerName.ToLower());
                if (manager == null)
                {
                    throw new InvalidOperationException("The manager is not found");
                }

                return manager.Drivers.SelectMany(d => d.Checks).ToList();
            });
        }

        public IEnumerable<Check> GetChecksByDriver(string driverName)
        {
            if (string.IsNullOrEmpty(driverName))
            {
                throw new ArgumentNullException("The driver name should not be empty");
            }

            return mtcHelper.Call<IEnumerable<Check>>(context =>
            {
                var driver = context.Drivers.FirstOrDefault(
                    d => d.Name.ToLower() == driverName.ToLower());
                if (driver == null)
                {
                    throw new InvalidOperationException("The driver is not found");
                }

                return driver.Checks.ToList();
            });
        }

        public IEnumerable<DriverCheck> GetDriverCheck()
        {
            throw new NotImplementedException();
        }
    }
}
