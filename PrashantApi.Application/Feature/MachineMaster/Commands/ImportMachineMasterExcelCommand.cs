using MediatR;
using Microsoft.AspNetCore.Http;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Application.Feature.MachineMaster.Commands
{
    public class ImportMachineMasterExcelCommand : IRequest<CommandResult>
    {
        public IFormFile File { get; set; } = default!;
    }
}
