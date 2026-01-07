using MediatR;
using PrashantApi.Application.DTOs.PurchaseOrder;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Application.Feature.PurchaseOrder.Commands
{
    public class UpdatePurchaseOrderCommand : IRequest<CommandResult>
    {
        public PurchaseOrderMasterDto PurchaseOrder { get; set; } = default!;
    }
}
