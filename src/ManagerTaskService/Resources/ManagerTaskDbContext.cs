namespace ManagerTaskService.Resources
{
    using ManagerTask.Data;

    /// <summary>
    /// The manager database context
    /// </summary>
    public class ManagerTaskDbContext : ManagerTaskContext
    {
        /// <summary>
        /// Creates the task database context
        /// </summary>
        /// <returns>The manager task database context</returns>
        public static ManagerTaskDbContext Create()
        {
            return new ManagerTaskDbContext();
        }
    }
}