using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TargetSystem.Models
{
    public class TargetApplicationUser
    {
        [Key, Column(Order = 0)]
        public string UserId { get; set; }
        [Key, Column(Order = 1)]
        public int TargetsId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Target Target { get; set; }

        public string Report { get; set; }
    }
}