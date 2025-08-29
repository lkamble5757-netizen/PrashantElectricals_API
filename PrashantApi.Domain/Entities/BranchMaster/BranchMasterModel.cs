using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Domain.Entities.BranchMaster
{
    public class BranchMasterModel
    {
        public int Id { get; set; }
        public string BranchName { get; set; }
        public string Address { get; set; }
        //public bool IsActive { get; set; }
    }
}
