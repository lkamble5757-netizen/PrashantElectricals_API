using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrashantApi.Application.DTOs.RoleMaster;

namespace PrashantApi.Application.Interfaces
{
    public interface IRoleMasterService
    {
        Task<int> AddAsync(RoleMasterDto dto);
        Task<int> UpdateAsync(RoleMasterDto dto);
        Task<List<RoleMasterDto>> GetAllAsync();
        Task<RoleMasterDto> GetByIdAsync(int id);
    }
}
