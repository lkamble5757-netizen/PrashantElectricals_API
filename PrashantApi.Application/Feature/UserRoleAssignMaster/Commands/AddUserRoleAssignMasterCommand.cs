using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Application.Feature.UserRoleAssignMaster.Commands
{
    public class AddUserRoleAssignMasterCommand : IRequest
    {
        public int UserId { get; set; }
        public List<int> RoleId { get; set; } = new(); 
        public bool IsActive { get; set; } = true;
        public bool IsObsolete { get; set; } = false;
        public int CreatedBy { get; set; } = 0;

    }
}
