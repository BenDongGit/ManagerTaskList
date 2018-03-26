namespace ManagerTask.Data
{
    using System;
    using System.Collections.Generic;

    public class DriverCheck
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public Driver Operative { get; set; }

        public IEnumerable<Check> Checks { get; set; }
    }
}