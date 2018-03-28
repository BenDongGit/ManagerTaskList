namespace ManagerTaskService
{
    using System.Web.Http;

    /// <summary>
    /// The web API config
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Registers the http config
        /// </summary>
        /// <param name="config">The http config</param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
