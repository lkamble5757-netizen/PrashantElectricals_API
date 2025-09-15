using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrashantApi.Application.DTOs.CustomerMaster;

namespace PrashantApi.Application.Interfaces
{
    public interface ICustomerMasterService
    {
        Task<int> AddAsync(CustomerMasterDto dto);
        Task<int> UpdateAsync(CustomerMasterDto dto);
        Task<List<CustomerMasterDto>> GetAllAsync();
        Task<CustomerMasterDto> GetByIdAsync(int id);
    }
}
