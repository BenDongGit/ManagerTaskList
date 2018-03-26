using System;
using System.Collections.Generic;
using System.Linq;

namespace ManagerTaskList
{
    public class ManagerTaskListService
    {
        private readonly Driver _john = new Driver { Id = 1, Name = "John Smith", DateJoinedCompany = DateTime.Parse("2017-05-01") };
        private readonly Driver _steve = new Driver { Id = 2, Name = "Steve Thompson", DateJoinedCompany = DateTime.Parse("2016-11-01") };
        private readonly Driver _matt = new Driver { Id = 3, Name = "Matt Jones",  DateJoinedCompany = DateTime.Parse("2016-11-01") };
        private readonly Driver _jane = new Driver { Id = 4, Name = "Jane Thomas", DateJoinedCompany = DateTime.Parse("2017-08-01") };
        private readonly Driver _sarah = new Driver { Id = 5, Name = "Sarah Clarke", DateJoinedCompany = DateTime.Parse("2016-11-01") };

        public IEnumerable<DriverCheck> GetDriverCheck()
        {
            var checks = GetChecks().ToList();

            var driverCheckRun = new List<DriverCheck>
            {
                new DriverCheck
                {
                    Id = 1,
                    Date = DateTime.Parse("2017-10-01"),
                    Operative = _john,
                    Checks = checks.Where(a => a.DrivedId == _john.Id)
                },
                new DriverCheck
                {
                    Id = 2,
                    Date = DateTime.Parse("2017-10-01"),
                    Operative = _matt,
                    Checks = checks.Where(a => a.DrivedId == _matt.Id)
                },
                new DriverCheck
                {
                    Id = 3,
                    Date = DateTime.Parse("2017-10-01"),
                    Operative = _sarah,
                    Checks = checks.Where(a => a.DrivedId == _sarah.Id)
                },
                new DriverCheck
                {
                    Id = 4,
                    Date = DateTime.Parse("22017-10-01"),
                    Operative = _jane,
                    Checks = checks.Where(a => a.DrivedId == _jane.Id)
                },
                new DriverCheck
                {
                    Id = 5,
                    Date = DateTime.Parse("2017-10-01"),
                    Operative = _steve,
                    Checks = checks.Where(a => a.DrivedId == _steve.Id)
                }
            };

            return driverCheckRun;
        }

        public IEnumerable<Check> GetChecks()
        {
            var checks = new List<Check>
            {
                new Check
                {
                    Date = DateTime.Parse("2017-10-01"),
                    Type = CheckType.License,
                    DrivedId = 1,
                    Success = true
                },
                new Check
                {
                    Date = DateTime.Parse("2017-10-01"),
                    Type = CheckType.PhotocardExpired,
                    DrivedId = 1,
                    Success = false
                },
                new Check
                {
                    Date = DateTime.Parse("2017-10-05"),
                    Type = CheckType.ValidID,
                    DrivedId = 1,
                    Success = true
                },
                new Check
                {
                    Date = DateTime.Parse("2017-10-05"),
                    Type = CheckType.License,
                    DrivedId = 2,
                    Success = true
                },
                new Check
                {
                    Date = DateTime.Parse("2017-09-28"),
                    Type = CheckType.ValidID,
                    DrivedId = 2,
                    Success = false
                },
                new Check
                {
                    Date = DateTime.Parse("2017-09-01"),
                    Type = CheckType.License,
                    DrivedId = 3,
                    Success = true
                },
                new Check
                {
                    Date = DateTime.Parse("2017-10-01"),
                    Type = CheckType.License,
                    DrivedId = 4,
                    Success = false
                },
                new Check
                {
                    Date = DateTime.Parse("2017-10-01"),
                    Type = CheckType.TrainingCompleted,
                    DrivedId = 4,
                    Success = false
                },
                new Check
                {
                    Date = DateTime.Parse("2017-10-01"),
                    Type = CheckType.ValidID,
                    DrivedId = 4,
                    Success = true
                },
                new Check
                {
                    Date = DateTime.Parse("2017-10-01"),
                    Type = CheckType.License,
                    DrivedId = 5,
                    Success = false
                },
                new Check
                {
                    Date = DateTime.Parse("2017-10-15"),
                    Type = CheckType.ValidID,
                    DrivedId = 5,
                    Success = true
                }
            };

            return checks;
        }
    }

    public class DriverCheck
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Driver Operative { get; set; }
        public IEnumerable<Check> Checks { get; set; }
    }

    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DateJoinedCompany { get; set; }
    }

    public class Check
    {
        public DateTime Date { get; set; }
        public CheckType Type { get; set; }
        public int DrivedId { get; set; }
        public Boolean Success { get; set; }
    }

    public enum CheckType
    {
        License,
        PhotocardExpired,
        ValidId,
        TrainingCompleted
    }
}
