namespace ManagerTaskService.Resources
{
    using ManagerTask.Data;

    public class ManagerTaskDbContext : ManagerTaskContext
    {
        public static ManagerTaskDbContext Create()
        {
            return new ManagerTaskDbContext();
        }
    }
}