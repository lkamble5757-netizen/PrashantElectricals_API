using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrashantApi.Application.DTOs.ItemMaster;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrashantApi.Application.Interfaces
{
    public interface IItemMasterService 
    {
        Task<int> AddAsync(ItemMasterDto dto);
        Task<int> UpdateAsync(ItemMasterDto dto);
        Task<List<ItemMasterDto>> GetAllAsync();
        Task<ItemMasterDto> GetByIdAsync(int id);

    }
}
