namespace TargetSystem.Models

{

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;

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

        [StringLength(500)]
        public string TargetDescription { get; set; }

        [ForeignKey("TargetType")]
        public int TargetTypeId { get; set; }

        public virtual TargetType TargetType { get; set; }

        public virtual ICollection<Position> Positions { get; set; }
    }
}