using MediatR;
using PrashantApi.Application.DTOs.Estimate;
using PrashantApi.Application.DTOs.RepairWork;
using PrashantEle.API.PrashantEle.Application.Common;
using System;
using System.Collections.Generic;

namespace PrashantApi.Application.Feature.RepairWork.Commands
{
    public class AddRepairWorkCommand : IRequest<CommandResult>
    {
        public RepairWorkDto RepairWork { get; set; } = default!;
    }

}
