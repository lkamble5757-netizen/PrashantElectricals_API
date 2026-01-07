using PrashantApi.Domain.Entities.StockUpdateMaster;
using PrashantEle.API.PrashantEle.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Application.Interfaces.StockUpdateMaster
{
    public interface IStockUpdateRepository
    {
        Task<CommandResult> AddAsync(StockUpdateMasterModel entity);
        Task<CommandResult> UpdateAsync(StockUpdateMasterModel entity);
        Task<dynamic> GetAllAsync();
        Task<dynamic> GetByIdAsync(int id);
    }

}
