using PrashantApi.Domain.Entities.PurchaseOrder;
using PrashantEle.API.PrashantEle.Application.Common;
using System.Threading.Tasks;

namespace PrashantApi.Application.Interfaces.PurchaseOrder
{
    public interface IPurchaseOrderRepository
    {
        Task<CommandResult> AddAsync(PurchaseOrderMasterModel entity);
        Task<CommandResult> UpdateAsync(PurchaseOrderMasterModel entity);
        Task<dynamic> GetAllAsync();
        Task<dynamic> GetByIdAsync(int id);
    }
}
