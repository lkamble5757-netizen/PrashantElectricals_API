using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrashantApi.Application.DTOs.RoleWiseMenuMaster;

namespace PrashantApi.Application.Interfaces
{
    public interface IRoleWiseMenuMasterService
    {
        Task AddAsync(RoleWiseMenuMasterDto dto);
        Task UpdateAsync(RoleWiseMenuMasterDto dto);
        Task<List<dynamic>> GetAllAsync();
        Task<List<dynamic>> GetByIdAsync(int id);
    }
}
