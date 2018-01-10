namespace TargetSystem.Models

{

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;
    using System;

    public class Target
    {

        private ICollection<TargetApplicationUser> targetApplicationUser;
        public Target()
        {
            this.targetApplicationUser = new HashSet<TargetApplicationUser>();
        }




        [Key]
        [Required]
        public int TargetsId { get; set; }

        [StringLength(300)]
        public string TargetGoal { get; set; }

        [MaxLength]
        public string TargetDescription { get; set; }

        public string Creator { get; set; }

        public virtual TargetType TargetType { get; set; }

        public double TargetPercent { get; set; }
        
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public virtual ICollection<TargetApplicationUser> TargetApplicationUser
        {
            get
            {
                return this.targetApplicationUser;
            }
            set
            {
                this.targetApplicationUser = value;
            }
        }
    }
}