using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PrashantApi.Application.DTOs.JobEntry;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Application.Feature.JobEntry.Commands
{
    public class AddJobEntryCommand : IRequest<CommandResult>
    {
        public JobEntryDto JobEntry { get; set; } = default!;

    }
}
