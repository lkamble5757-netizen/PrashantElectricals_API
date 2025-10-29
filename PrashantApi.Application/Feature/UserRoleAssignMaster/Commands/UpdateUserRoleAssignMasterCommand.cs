using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PrashantEle.API.PrashantEle.Application.Common;
using PrashantApi.Application.DTOs.UserRoleAssignMaster;

namespace PrashantApi.Application.Feature.UserRoleAssignMaster.Commands
{
    public class UpdateUserRoleAssignMasterCommand : IRequest<CommandResult>
    {
        public UserRoleAssignMasterDto UserRoleAssignMaster { get; set; } = default!;
    }   
}
