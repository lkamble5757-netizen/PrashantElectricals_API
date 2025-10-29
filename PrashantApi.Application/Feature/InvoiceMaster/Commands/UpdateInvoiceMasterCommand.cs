using MediatR;
using PrashantApi.Application.DTOs.InvoiceMaster;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Application.Feature.InvoiceMaster.Commands
{
    public class UpdateInvoiceMasterCommand : IRequest<CommandResult>
    {
        public InvoiceMasterDto InvoiceMaster { get; set; } = default!;
    }
}
