using MediatR;
using PrashantEle.API.PrashantEle.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrashantApi.Application.DTOs.RoleMaster;

namespace PrashantApi.Application.Feature.RoleMaster.Commands
{
    public class UpdateRoleMasterCommand : IRequest<CommandResult>
    {
        public RoleMasterDto RoleMaster { get; set; } = default!;
    }
}
