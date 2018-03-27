namespace ManagerTask.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class ManagerTaskContext : IdentityDbContext<Manager>
    {
        public ManagerTaskContext() : base("ManagerTaskService", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<Check> Checks { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer<ManagerTaskContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}
