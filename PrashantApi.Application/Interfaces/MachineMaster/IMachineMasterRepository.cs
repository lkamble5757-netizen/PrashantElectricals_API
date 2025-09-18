using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrashantApi.Domain.Entities.MachineMaster;

namespace PrashantApi.Application.Interfaces.MachineMaster
{
    public interface IMachineMasterRepository
    {
        Task<int> AddAsync(MachineMasterModel entity);
        Task<int> UpdateAsync(MachineMasterModel entity);
        Task<List<MachineMasterModel>> GetAllAsync();
        Task<MachineMasterModel> GetByIdAsync(int id);
    }
}

