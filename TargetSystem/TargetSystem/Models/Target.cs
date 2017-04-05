namespace TargetSystem.Models

{

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;
    using System;

    public class Target
    {
        private ICollection<Position> positions;

        public Target()
        {
            this.positions = new HashSet<Position>();
        }

        [Key]
        [Required]
        public int TargetsId { get; set; }

        [StringLength(300)]
        public string TargetGoal { get; set; }

        [MaxLength]
        public string TargetDescription { get; set; }

        //[ForeignKey("TargetType")]
        //public int TargetTypeId { get; set; }

        public virtual TargetType TargetType { get; set; }

        public decimal TargetMoney { get; set; }

        public virtual ICollection<Position> Positions
        {
            get { return this.positions; }
            set { this.positions = value; }
        }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }


        [ForeignKey("Creator")]
        public string CreatorId { get; set; }

        public virtual ApplicationUser Creator { get; set; }

    }
}