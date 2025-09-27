using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrashantApi.Domain.Entities.RoleWiseMenuMaster;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Application.Interfaces.RoleWiseMenuMaster
{
    public interface IRoleWiseMenuMasterRepository
    {
        Task<CommandResult> AddAsync(RoleWiseMenuMasterModel entity);
        Task<CommandResult> UpdateAsync(RoleWiseMenuMasterModel entity);
        Task<List<dynamic>> GetAllAsync();
        Task<List<dynamic>> GetByIdAsync(int id);
    }
}
