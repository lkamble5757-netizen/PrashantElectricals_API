using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Domain.Entities.UserRoleAssignMaster
{
    public class UserRoleAssignMasterModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<int> RoleId { get; set; } = new();
        public bool IsActive { get; set; }
        public bool IsObsolete { get; set; }
        public int CreatedBy { get; set; } = 0;
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
