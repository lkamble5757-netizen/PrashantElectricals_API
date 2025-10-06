using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrashantApi.Domain.Entities.Estimate;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Application.Interfaces.Estimate
{
    public interface IEstimateRepository
    {
        Task<CommandResult> AddAsync(EstimateModel entity);
        Task<CommandResult> UpdateAsync(EstimateModel entity);
        Task<IEnumerable<EstimateModel>> GetAllAsync();
        Task<IEnumerable<EstimateModel>> GetByIdAsync(int id);
    }
}
