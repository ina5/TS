namespace TargetSystem.Models

{

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;
    using System;

    public class Target
    {

        private ICollection<ApplicationUser> users;
        public Target()
        {
            this.users = new HashSet<ApplicationUser>();
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

        //[Required]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        //[Required]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }


        public virtual ICollection<ApplicationUser> User
        {
            get
            {
                return this.users;
            }
            set
            {
                this.users = value;
            }
        }

    }
}