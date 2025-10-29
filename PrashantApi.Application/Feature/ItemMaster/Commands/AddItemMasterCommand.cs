using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PrashantApi.Application.DTOs.ItemMaster;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Application.Feature.ItemMaster.Commands
{
    public class AddItemMasterCommand : IRequest<CommandResult>
    {
        public ItemMasterDto ItemMaster { get; set; } = default!;
    }
}