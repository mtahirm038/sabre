﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.ViewModel
{
    public class EmployeeViewModel
    {
        public string DisplayName { get; set; }
        public IList<string> Responsibilities { get; set; }

    }
}
