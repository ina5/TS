namespace TargetSystem.Models

{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;

    public class Positions
    {
        private ICollection<ApplicationUser> users;

        public Positions()
        {
            this.ApplicationUser = new HashSet<ApplicationUser>();
        }

        [Key]
        public int PositionId { get; set; }

        [Required]
        [StringLength(500)]
        public string PositionName { get; set; }

        [ForeignKey("Targets")]
        public int TargetsId { get; set; }

        public virtual Targets Target { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUser { get; set; }
    }
}