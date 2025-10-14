using PrashantApi.Application.DTOs.Estimate;
using PrashantApi.Application.DTOs.RepairWork;
using PrashantEle.API.PrashantEle.Application.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrashantApi.Application.Interfaces
{
    public interface IRepairWorkService
    {
        Task<CommandResult> AddAsync(RepairWorkDto dto);
        Task<CommandResult> UpdateAsync(RepairWorkDto dto);
        Task<List<RepairWorkDto>> GetAllAsync();
        Task<RepairWorkDto?> GetByIdAsync(int id);
    }
}
