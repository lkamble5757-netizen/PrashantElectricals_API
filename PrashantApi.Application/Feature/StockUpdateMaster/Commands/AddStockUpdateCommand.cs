using MediatR;
using PrashantApi.Application.DTOs.StockUpdateMaster;
using PrashantEle.API.PrashantEle.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Application.Feature.StockUpdateMaster.Commands
{
    public class AddStockUpdateCommand : IRequest<CommandResult>
    {
        public StockUpdateMasterDto StockUpdate { get; set; } = default!;
    }

}
