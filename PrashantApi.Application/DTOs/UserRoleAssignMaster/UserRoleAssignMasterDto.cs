using PrashantApi.Application.DTOs.CommonDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Application.DTOs.UserRoleAssignMaster
{
    public class UserRoleAssignMasterDto : BaseDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<int> RoleId { get; set; } = new();
        public bool IsObsolete { get; set; }
    }
}
