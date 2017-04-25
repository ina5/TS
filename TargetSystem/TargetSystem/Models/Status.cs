using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TargetSystem.Models
{
    public class Status
    {

        [Key]
        [Required]
        public int StatusId { get; set; }

        public string StatusName { get; set; }
    }
}