using PrashantApi.Domain.Entities.InvoiceMaster;
using PrashantEle.API.PrashantEle.Application.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrashantApi.Application.Interfaces.InvoiceMaster
{
    public interface IInvoiceMasterRepository
    {
        Task<CommandResult> AddAsync(InvoiceMasterModel entity);
        Task<CommandResult> UpdateAsync(InvoiceMasterModel entity);
        Task<List<InvoiceMasterModel>> GetAllAsync();
        Task<dynamic?> GetByIdAsync(int id);
        Task<dynamic> GetCustomerWiseRepairDataAsync(int customerId);
    }
}
