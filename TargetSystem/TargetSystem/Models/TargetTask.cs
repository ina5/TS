using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TargetSystem.Models
{
    public class TargetTask
    {

        [Key]
        public int TaskId { get; set; }

        [StringLength(500)]
        public string TaskDescription { get; set; }

        [ForeignKey("Target")]
        public int TargetId { get; set; }

        public virtual Target Target { get; set; }

        [ForeignKey("TaskStatus")]
        public int TaskStatusId { get; set; }

        public virtual TaskStatus TaskStatus { get; set; }
    }
}