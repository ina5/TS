﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TargetSystem.ViewModel
{
    public class TargetView
    {
        public int Id { get; set; }

        public string Goal { get; set; }

        public string Type { get; set; }

        public decimal? Percent { get; set; }

        public string Creator { get; set; }
    }
}