namespace ManagerTask.Data
{
    using System.Data.Entity;

    public class ManagerTaskContext : DbContext
    {
        public ManagerTaskContext() : base("ManagerTaskService")
        {
        }

        public virtual DbSet<Check> Checks { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ManagerTaskContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}
