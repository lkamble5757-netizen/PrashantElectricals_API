using MediatR;
using PrashantApi.Application.DTOs.Estimate;
using PrashantEle.API.PrashantEle.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Application.Feature.Estimate.Commands
{
    public class UpdateEstimateMasterCommand : IRequest<CommandResult>
    {
        public EstimateMasterDto EstimateMaster { get; set; } = default!;
    }
}
