using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Application.Feature.ItemMaster.Commands
{
    public class ImportItemMasterExcelCommand : IRequest<CommandResult>
    {
        public IFormFile File { get; set; } = default!;
    }
}

