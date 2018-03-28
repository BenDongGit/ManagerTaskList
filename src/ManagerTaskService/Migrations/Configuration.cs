namespace ManagerTaskService.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// The migration configuration
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<ManagerTaskService.Resources.ManagerTaskDbContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class
        /// </summary>
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        /// <summary>
        /// The seed
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(ManagerTaskService.Resources.ManagerTaskDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
