using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrashantApi.Domain.Entities.CustomerMaster;

namespace PrashantApi.Application.Interfaces.CustomerMaster
{
    public interface ICustomerMasterRepository
    {
        Task<int> AddAsync(CustomerMasterModel entity);
        Task<int> UpdateAsync(CustomerMasterModel entity);
        Task<List<CustomerMasterModel>> GetAllAsync();
        Task<CustomerMasterModel> GetByIdAsync(int id);
    }
}
