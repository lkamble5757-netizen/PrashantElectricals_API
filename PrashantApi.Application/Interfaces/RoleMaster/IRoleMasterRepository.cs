using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrashantApi.Domain.Entities.RoleMaster;

namespace PrashantApi.Application.Interfaces.RoleMaster
{
    public interface IRoleMasterRepository
    {
        Task<int> AddAsync(RoleMasterModel entity);
        Task<int> UpdateAsync(RoleMasterModel entity);
        Task<List<RoleMasterModel>> GetAllAsync();
        Task<RoleMasterModel> GetByIdAsync(int id);
    }
}
