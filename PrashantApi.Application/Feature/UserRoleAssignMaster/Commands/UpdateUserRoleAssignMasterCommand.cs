using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Application.Feature.UserRoleAssignMaster.Commands
{
    public class UpdateUserRoleAssignMasterCommand : IRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<int> RoleId { get; set; } = new();
        public bool IsActive { get; set; }
        public bool IsObsolete { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
