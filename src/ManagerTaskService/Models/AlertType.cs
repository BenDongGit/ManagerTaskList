namespace ManagerTaskService.Models
{
    /// <summary>
    /// The alert type
    /// </summary>
    public enum AlertType
    {
        /// <summary>
        /// The check missing type
        /// </summary>
        CheckMissing,

        /// <summary>
        /// The check failed type
        /// </summary>
        CheckFailed,

        /// <summary>
        /// The check expired type
        /// </summary>
        CheckExpired,

        /// <summary>
        /// The check expiring type
        /// </summary>
        CheckExpiring
    }
}