using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrashantApi.Application.DTOs.ItemMaster;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Application.Feature.ItemMaster.Commands
{
    public class UpdateItemMasterCommand : IRequest<CommandResult>
    {
        public ItemMasterDto ItemMaster { get; set; } = default!;
    }
}