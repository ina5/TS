namespace TargetSystem.Models

{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;

    public class TargetType
    {
        private ICollection<Target> targets;

        public TargetType()
        {
            this.targets = new HashSet<Target>();
        }

        [Key]
        public int TargetTypeId { get; set; }

     
        [StringLength(500)]
        public string TargetTypeName { get; set; }

        public virtual ICollection<Target> Targets { get; set; }
    }
}