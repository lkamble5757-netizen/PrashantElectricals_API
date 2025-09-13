using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrashantApi.Domain.Entities.ItemMaster;


namespace PrashantApi.Application.Interfaces.ItemMaster
{
    public interface IItemMasterRepository
    {
        Task<int> AddAsync(ItemMasterModel entity);
        Task<int> UpdateAsync(ItemMasterModel entity);
        Task<List<ItemMasterModel>> GetAllAsync();
        Task<ItemMasterModel> GetByIdAsync(int id);
    }
}
