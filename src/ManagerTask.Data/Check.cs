namespace ManagerTask.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The check
    /// </summary>
    public class Check
    {
        /// <summary>
        /// Gets or sets the check indeity
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the driver identity
        /// </summary>
        [ForeignKey("Driver")]
        public int DriverId { get; set; }

        /// <summary>
        /// Gets or sets the check type
        /// </summary>
        [Required]
        public int Type { get; set; }

        /// <summary>
        /// Gets or sets the check date
        /// </summary>
        [Required]
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the check success status
        /// </summary>
        [Required]
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the driver
        /// </summary>
        public virtual Driver Driver { get; set; }
    }
}