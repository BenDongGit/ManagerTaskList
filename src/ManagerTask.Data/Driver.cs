namespace ManagerTask.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The driver
    /// </summary>
    public class Driver
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Driver"/> class
        /// </summary>
        public Driver()
        {
            Checks = new HashSet<Check>();
        }

        /// <summary>
        /// Gets or sets the driver identity
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the manager identity
        /// </summary>
        [ForeignKey("Manager")]
        public string ManagerId { get; set; }

        /// <summary>
        /// Gets or sets the driver name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the date the driver joined company
        /// </summary>
        public DateTime? DateJoinedCompany { get; set; }

        /// <summary>
        /// Gets or sets the manager
        /// </summary>
        public virtual Manager Manager { get; set; }

        /// <summary>
        /// Gets or sets the checks
        /// </summary>
        public virtual ICollection<Check> Checks { get; set; }
    }
}