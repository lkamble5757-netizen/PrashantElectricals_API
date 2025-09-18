using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrashantApi.Application.DTOs.MachineMaster;

namespace PrashantApi.Application.Interfaces
{
    public interface IMachineMasterService
    {
        Task<int> AddAsync(MachineMasterDto dto);
        Task<int> UpdateAsync(MachineMasterDto dto);
        Task<List<MachineMasterDto>> GetAllAsync();
        Task<MachineMasterDto> GetByIdAsync(int id);
    }
}

