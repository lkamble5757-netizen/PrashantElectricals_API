using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrashantApi.Domain.Entities.MachineMaster;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Application.Interfaces.MachineMaster
{
    public interface IMachineMasterRepository
    {
        Task<CommandResult> AddAsync(MachineMasterModel entity);
        Task<CommandResult> UpdateAsync(MachineMasterModel entity);
        Task<dynamic> GetAllAsync();
        Task<dynamic> GetByIdAsync(int id);
        Task<CommandResult> BulkInsertAsync(List<MachineMasterModel> machines);
    }
}