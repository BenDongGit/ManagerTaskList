namespace ManagerTaskService
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin;
    using Microsoft.Owin.Security;
    using ManagerTask.Data;
    using ManagerTaskService.Resources;

    /// <summary>
    /// The email service
    /// </summary>
    public class EmailService : IIdentityMessageService
    {
        /// <summary>
        /// Sends the message async
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>The task</returns>
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }

    /// <summary>
    /// The sms service
    /// </summary>
    public class SmsService : IIdentityMessageService
    {
        /// <summary>
        /// Sends the message async
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>The task</returns>
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }

    /// <summary>
    /// The user manager
    /// </summary>
    public class UserManager : UserManager<Manager>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserManager"/> class
        /// </summary>
        /// <param name="store">The user store</param>
        public UserManager(IUserStore<Manager> store)
            : base(store)
        {
        }

        /// <summary>
        /// Creates the user manager
        /// </summary>
        /// <param name="options">The factory options.</param>
        /// <param name="context">The owin context.</param>
        /// <returns>The user manager</returns>
        public static UserManager Create(IdentityFactoryOptions<UserManager> options, IOwinContext context)
        {
            var manager = new UserManager(new UserStore<Manager>(context.Get<ManagerTaskDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<Manager>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<Manager>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<Manager>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<Manager>(dataProtectionProvider.Create("Identity"));
            }
            return manager;
        }
    }

    /// <summary>
    /// The sign in manager
    /// </summary>
    public class SignInManager : SignInManager<Manager, string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SignInManager"/> class
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="authenticationManager"></param>
        public SignInManager(UserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        /// <summary>
        /// Creates the user identity async
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>Task wrapper with claims</returns>
        public override Task<ClaimsIdentity> CreateUserIdentityAsync(Manager user)
        {
            return user.GenerateUserIdentityAsync((UserManager)UserManager);
        }

        /// <summary>
        /// Creates the sign in manager
        /// </summary>
        /// <param name="options">The user.</param>
        /// <param name="context">The owin context.</param>
        /// <returns>Task sign in manager</returns>
        public static SignInManager Create(IdentityFactoryOptions<SignInManager> options, IOwinContext context)
        {
            return new SignInManager(context.GetUserManager<UserManager>(), context.Authentication);
        }
    }
}