namespace ManagerTaskService.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security;

    /// <summary>
    /// The index view model
    /// </summary>
    public class IndexViewModel
    {
        /// <summary>
        /// Gets or sets the value indicating whether there is password
        /// </summary>
        public bool HasPassword { get; set; }

        /// <summary>
        /// Gets or sets the login users 
        /// </summary>
        public IList<UserLoginInfo> Logins { get; set; }

        /// <summary>
        /// Gets or sets the phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether to use two factor to authorize
        /// </summary>
        public bool TwoFactor { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether the browser is remembered
        /// </summary>
        public bool BrowserRemembered { get; set; }
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    /// <summary>
    /// The factor view model
    /// </summary>
    public class FactorViewModel
    {
        /// <summary>
        /// Gets or sets the purpose
        /// </summary>
        public string Purpose { get; set; }
    }

    /// <summary>
    /// Gets or sets the set password view model
    /// </summary>
    public class SetPasswordViewModel
    {
        /// <summary>
        /// Gets or sets the new password
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        /// <summary>
        /// Gets or sets the confirm password
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    /// <summary>
    /// The change password view model
    /// </summary>
    public class ChangePasswordViewModel
    {
        /// <summary>
        /// Gets or sets the old password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        /// <summary>
        /// Gets or sets the new password
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        /// <summary>
        /// Gets or sets the confirm password
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    /// <summary>
    /// The add phone number view model
    /// </summary>
    public class AddPhoneNumberViewModel
    {
        /// <summary>
        /// Gets or sets the number
        /// </summary>
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }

    /// <summary>
    /// The verify phone number view model
    /// </summary>
    public class VerifyPhoneNumberViewModel
    {
        /// <summary>
        /// Gets or sets the code 
        /// </summary>
        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the phone number
        /// </summary>
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }

    /// <summary>
    /// The configure two factor view model
    /// </summary>
    public class ConfigureTwoFactorViewModel
    {
        /// <summary>
        /// Gets or sets the selected provider
        /// </summary>
        public string SelectedProvider { get; set; }

        /// <summary>
        /// Gets or sets the providers
        /// </summary>
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}