namespace ManagerTask.Data
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    /// <summary>
    /// The manager
    /// </summary>
    public class Manager : IdentityUser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Manager"/> class
        /// </summary>
        public Manager() : base()
        {
            Drivers = new HashSet<Driver>();
        }

        /// <summary>
        /// Gets or sets the drivers
        /// </summary>
        public virtual ICollection<Driver> Drivers { get; set; }

        /// <summary>
        /// Generates the user identity async
        /// </summary>
        /// <param name="manager">The manager.</param>
        /// <returns>The claims' identity</returns>
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Manager> manager)
        {
            return await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}
