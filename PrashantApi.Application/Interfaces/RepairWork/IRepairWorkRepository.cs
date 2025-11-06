using PrashantApi.Domain.Entities.Estimate;
using PrashantApi.Domain.Entities.RepairWork;
using PrashantEle.API.PrashantEle.Application.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrashantApi.Application.Interfaces.RepairWork
{
    public interface IRepairWorkRepository
    {
        Task<CommandResult> AddAsync(RepairWorkModel entity);
        Task<CommandResult> UpdateAsync(RepairWorkModel entity);
        Task<dynamic> GetAllAsync();
        Task<dynamic> GetByIdAsync(int id);
        Task<dynamic> GetEstimateMasterFeildsByIdAsync(int estimatedId);
    }
}
