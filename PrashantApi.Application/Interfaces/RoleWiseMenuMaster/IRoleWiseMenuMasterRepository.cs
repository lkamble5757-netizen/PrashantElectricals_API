using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrashantApi.Domain.Entities.RoleWiseMenuMaster;

namespace PrashantApi.Application.Interfaces.RoleWiseMenuMaster
{
    public interface IRoleWiseMenuMasterRepository
    {
        Task AddAsync(RoleWiseMenuMasterModel entity);
        Task UpdateAsync(RoleWiseMenuMasterModel entity);
        Task<List<dynamic>> GetAllAsync();
        Task<List<dynamic>> GetByIdAsync(int id);
    }
}
