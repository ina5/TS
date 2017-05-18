using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TargetSystem.Models
{
    public class TaskStatus
    {
        private ICollection<TargetTask> tasks;

        public TaskStatus()
        {
            this.tasks = new HashSet<TargetTask>();
        }

        [Key]
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<TargetTask> Tasks
        {
            get
            {
                return this.tasks;
            }
            set
            {
                this.tasks = value;
            }
        }
    }
}