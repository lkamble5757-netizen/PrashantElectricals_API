﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Infrastructure.Entities.BranchMaster
{
    public class BranchMaster
    {
        public int Id { get; set; }
        public string BranchName { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
    }
}
