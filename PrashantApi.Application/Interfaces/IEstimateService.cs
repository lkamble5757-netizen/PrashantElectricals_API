using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrashantApi.Application.DTOs.Estimate;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Application.Interfaces
{
    public interface IEstimateService
    {
        Task<CommandResult> AddAsync(EstimateDto dto);
        Task<CommandResult> UpdateAsync(EstimateDto dto);
        Task<IEnumerable<EstimateDto>> GetAllAsync();
        Task<IEnumerable<EstimateDto>> GetByIdAsync(int id);
    }
}
