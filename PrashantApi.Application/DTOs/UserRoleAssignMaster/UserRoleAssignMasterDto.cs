using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Application.DTOs.UserRoleAssignMaster
{
    public class UserRoleAssignMasterDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<int> RoleId { get; set; } = new();
        public bool IsActive { get; set; }
        public bool IsObsolete { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
