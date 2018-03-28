using Microsoft.Owin;
[assembly: OwinStartupAttribute(typeof(ManagerTaskService.Startup))]

namespace ManagerTaskService
{
    using Owin;

    /// <summary>
    /// The start up class
    /// </summary>
    public partial class Startup
    {
        /// <summary>
        /// The configuration
        /// </summary>
        /// <param name="app">The application builder</param>
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}