using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Domain.Entities.RoleWiseMenuMaster
{
    public class RoleWiseMenuMasterModel
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public List<int> MenuId { get; set; } = new();
        public bool IsActive { get; set; }
        public bool IsObsolete { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
