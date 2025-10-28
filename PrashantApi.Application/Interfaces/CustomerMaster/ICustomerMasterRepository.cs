using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrashantApi.Domain.Entities.CustomerMaster;
using PrashantEle.API.PrashantEle.Application.Common;
using System.Threading.Tasks;

namespace PrashantApi.Application.Interfaces.CustomerMaster
{
    public interface ICustomerMasterRepository
    {
        Task<CommandResult> AddAsync(CustomerMasterModel entity);
        Task<CommandResult> UpdateAsync(CustomerMasterModel entity);
        Task<dynamic> GetAllAsync();
        Task<dynamic> GetByIdAsync(int id);
    }
}