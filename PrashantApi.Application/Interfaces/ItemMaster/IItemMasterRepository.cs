using Microsoft.AspNetCore.Http;
using PrashantApi.Domain.Entities.ItemMaster;
using PrashantApi.Domain.Entities.MachineMaster;
using PrashantEle.API.PrashantEle.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Application.Interfaces.ItemMaster
{
    public interface IItemMasterRepository
    {
        Task<CommandResult> AddAsync(ItemMasterModel entity);
        Task<CommandResult> UpdateAsync(ItemMasterModel entity);
        Task<dynamic> GetAllAsync();
        Task<dynamic> GetByIdAsync(int id);
        Task<CommandResult> BulkInsertAsync(List<ItemMasterModel> items);
    }
}