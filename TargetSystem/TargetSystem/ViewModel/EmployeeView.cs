using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TargetSystem.ViewModel
{
    public class EmployeeView
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        [Browsable(false)]
        public bool IsSelected { get; set; }
    }
}