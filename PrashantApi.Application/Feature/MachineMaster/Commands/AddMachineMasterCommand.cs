using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PrashantEle.API.PrashantEle.Application.Common;
using PrashantApi.Application.DTOs.MachineMaster;

namespace PrashantApi.Application.Feature.MachineMaster.Commands
{
    public class AddMachineMasterCommand : IRequest<CommandResult>
    {
        public MachineMasterDto MachineMaster { get; set; } = default!;
    }
}