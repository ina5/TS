namespace TargetSystem.Models

{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;

    public class TargetType
    {
        private ICollection<Targets> targets;

        public TargetType()
        {
            this.Targets = new HashSet<Targets>();
        }

        [Key]
        public int TargetTypeId { get; set; }

        [Required]
        [StringLength(500)]
        public string TargetTypeName { get; set; }

        public virtual ICollection<Targets> Targets { get; set; }
    }
}