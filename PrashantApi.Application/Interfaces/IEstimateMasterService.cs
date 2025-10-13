using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrashantApi.Application.DTOs.Estimate;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Application.Interfaces
{
    public interface IEstimateMasterService
    {
        Task<CommandResult> AddAsync(EstimateMasterDto dto);   
        Task<CommandResult> UpdateAsync(EstimateMasterDto dto);
        Task<dynamic> GetAllAsync();  
        Task<dynamic> GetByIdAsync(int id);  
        Task<dynamic> GetJobNoByCustomerID(int id); 
    }

}
