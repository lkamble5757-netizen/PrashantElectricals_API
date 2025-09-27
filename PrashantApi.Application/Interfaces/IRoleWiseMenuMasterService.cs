using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrashantApi.Application.DTOs.RoleWiseMenuMaster;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Application.Interfaces
{
    public interface IRoleWiseMenuMasterService
    {
        Task<CommandResult> AddAsync(RoleWiseMenuMasterDto dto);
        Task<CommandResult> UpdateAsync(RoleWiseMenuMasterDto dto);
        Task<List<dynamic>> GetAllAsync();
        Task<List<dynamic>> GetByIdAsync(int id);
    }
}
