using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PrashantApi.Application.DTOs.LedgerMaster;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Application.Feature.LedgerMaster.Commands
{
    public class AddLedgerMasterCommand : IRequest<CommandResult>
    {
        public LedgerMasterDto Ledger { get; set; } = default!;
    }
}

