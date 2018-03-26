namespace ManagerTask.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Check
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Driver")]
        public int DriverId { get; set; }

        [Required]
        public int Type { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public bool Success { get; set; }

        public virtual Driver Driver { get; set; }
    }
}