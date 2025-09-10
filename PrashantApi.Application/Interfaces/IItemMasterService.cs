using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Application.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using PrashantApi.Application.DTOs.ItemMaster;

    public interface IItemMasterService
    {
        Task<int> AddOrUpdateItemAsync(ItemMasterDto itemDto);
        //Task<int> UpdateItemMaster(ItemMasterDto itemDto);
        Task<int> UpdateItemMaster(ItemMasterDto itemDto);

        Task<ItemMasterDto> GetItemByIdAsync(int id);
        Task<List<ItemMasterDto>> GetAllItemsAsync();
    }

}
