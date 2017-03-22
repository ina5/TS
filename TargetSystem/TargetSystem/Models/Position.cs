namespace TargetSystem.Models

{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;

    public class Position
    {
        private ICollection<ApplicationUser> users;

        public Position()
        {
            this.users = new HashSet<ApplicationUser>();
        }

        [Key]
        public int PositionId { get; set; }

    
        [StringLength(500)]
        public string PositionName { get; set; }

        [ForeignKey("Target")]
        public int TargetsId { get; set; }

        public virtual Target Target { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUser
        {
            get { return this.users; }
            set { this.users = value; }
        }
    }
}