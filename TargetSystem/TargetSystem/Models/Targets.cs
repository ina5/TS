namespace TargetSystem.Models

{

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;

    public class Targets
    {
        private ICollection<Positions> positions;
        
        public Targets()
        {
            this.Positions = new HashSet<Positions>();
        }

        [Key]
        [Required]
        public int TargetsId { get; set; }

        [StringLength(500)]
        public string TargetDescription { get; set; }

        [ForeignKey("TargetType")]
        public int TargetTypeId { get; set; }

        public virtual TargetType TargetType { get; set; }

        public virtual ICollection<Positions> Positions { get; set; }
    }
}