namespace ManagerTaskService
{
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// The route config
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Registers the routes
        /// </summary>
        /// <param name="routes">The route collection</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Alert", action = "GetAlerts", id = UrlParameter.Optional }
            );
        }
    }
}
