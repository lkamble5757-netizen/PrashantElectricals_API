using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrashantApi.Domain.Entities.LedgerMaster;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Application.Interfaces.LedgerMaster
{
    public interface ILedgerMasterRepository
    {
        Task<CommandResult> AddAsync(LedgerMasterModel entity);
        Task<CommandResult> UpdateAsync(LedgerMasterModel entity);
        Task<dynamic> GetAllAsync();
        Task<dynamic> GetByIdAsync(int id);
    }
}

