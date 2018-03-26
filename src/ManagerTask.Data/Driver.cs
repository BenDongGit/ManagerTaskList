namespace ManagerTask.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Driver
    {
        public Driver()
        {
            Checks = new HashSet<Check>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Manager")]
        public int ManagerId { get; set; }

        public string Name { get; set; }

        public DateTime? DateJoinedCompany { get; set; }

        public virtual Manager Manager { get; set; }

        public virtual ICollection<Check> Checks { get; set; }
    }
}