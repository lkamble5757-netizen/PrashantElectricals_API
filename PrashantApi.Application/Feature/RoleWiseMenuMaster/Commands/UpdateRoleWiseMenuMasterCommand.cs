using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PrashantApi.Application.DTOs.RoleWiseMenuMaster;
using PrashantEle.API.PrashantEle.Application.Common;


namespace PrashantApi.Application.Feature.RoleWiseMenuMaster.Commands
{
    public class UpdateRoleWiseMenuMasterCommand : IRequest<CommandResult>
    {
        public RoleWiseMenuMasterDto RoleWiseMenuMaster { get; set; } = default!;
    }
}
