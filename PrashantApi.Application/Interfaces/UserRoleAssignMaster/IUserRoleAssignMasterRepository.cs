using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrashantApi.Domain.Entities.UserRoleAssignMaster;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Application.Interfaces.UserRoleAssignMaster
{
    public interface IUserRoleAssignMasterRepository
    {
        Task<CommandResult> AddAsync(UserRoleAssignMasterModel entity);
        Task<CommandResult> UpdateAsync(UserRoleAssignMasterModel entity);
        Task<dynamic> GetAllAsync();
        Task<dynamic> GetByIdAsync(int id);
    }
}
