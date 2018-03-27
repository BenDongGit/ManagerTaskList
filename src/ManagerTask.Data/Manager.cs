namespace ManagerTask.Data
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class Manager : IdentityUser
    {
        public Manager() : base()
        {
            Drivers = new HashSet<Driver>();
        }

        public virtual ICollection<Driver> Drivers { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Manager> manager)
        {
            return await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}
