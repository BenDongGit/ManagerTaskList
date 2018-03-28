namespace ManagerTaskService
{
    using System.Web.Mvc;
    using ManagerTaskService.ExceptionHandling;

    /// <summary>
    /// The fileter config
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// Registers the global filters.
        /// </summary>
        /// <param name="filters">The global filter collection.</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            // filters.Add(new ExceptionHandlingAttribute());
        }
    }
}
