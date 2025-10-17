using PrashantApi.Domain.Entities.RoleMaster;
using PrashantEle.API.PrashantEle.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Application.Interfaces.RoleMaster
{
    public interface IRoleMasterRepository
    {
        Task<CommandResult> AddAsync(RoleMasterModel entity);
        Task<CommandResult> UpdateAsync(RoleMasterModel entity);
        Task<dynamic> GetAllAsync();
        Task<dynamic> GetByIdAsync(int id);
    }
}
