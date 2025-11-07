using Microsoft.AspNetCore.Mvc;
using PrashantApi.Domain.Entities.ChallanMaster;
using PrashantEle.API.PrashantEle.Application.Common;
using System.Threading.Tasks;

namespace PrashantApi.Application.Interfaces.ChallanMaster
{
    public interface IChallanMasterRepository
    {
        Task<CommandResult> AddAsync(ChallanMasterModel entity);
        Task<CommandResult> UpdateAsync(ChallanMasterModel entity);
        Task<dynamic> GetAllAsync();
        Task<dynamic> GetByIdAsync(int id);
        Task<dynamic> GetInvoicesByCustomerIdAsync(int customerId);
        //  Task<dynamic> GetRepairWorkDetailsByJobIdAsync(int jobId);

        Task<dynamic> GetRepairWorkDetailsByInvoiceIdAsync(int invoiceId);

    }
}
