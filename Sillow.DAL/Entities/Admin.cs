﻿using Sillow.DAL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sillow.DAL.Entities
{
    public class Admin : Person
    {
        public bool IsActive { get; set; }

        public Admin() => IsActive = true;
    }
}
