namespace ManagerTask.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    /// <summary>
    /// The manager task context
    /// </summary>
    public class ManagerTaskContext : IdentityDbContext<Manager>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManagerTaskContext"/> class
        /// </summary>
        public ManagerTaskContext() : base("ManagerTaskService", throwIfV1Schema: false)
        {
        }

        /// <summary>
        /// Gets or sets the checks
        /// </summary>
        public virtual DbSet<Check> Checks { get; set; }

        /// <summary>
        /// Gets or sets the drivers
        /// </summary>
        public virtual DbSet<Driver> Drivers { get; set; }
    }
}
