using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrashantApi.Application.DTOs.UserRoleAssignMaster;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Application.Interfaces
{
    public interface IUserRoleAssignMasterService
    {
        Task<CommandResult> AddAsync(UserRoleAssignMasterDto dto);
        Task<CommandResult> UpdateAsync(UserRoleAssignMasterDto dto);
        Task<IEnumerable<dynamic>> GetAllAsync();
        Task<IEnumerable<dynamic>> GetByIdAsync(int id);
    }
}
