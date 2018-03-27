using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ManagerTaskService.Startup))]
namespace ManagerTaskService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}