using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrashantApi.Domain.Entities.Estimate;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Application.Interfaces.Estimate
{
    public interface IEstimateMasterRepository
    {
        Task<CommandResult> AddAsync(EstimateMasterModel entity);      
        Task<CommandResult> UpdateAsync(EstimateMasterModel entity); 
        Task<dynamic> GetAllAsync();                            
        Task<dynamic> GetByIdAsync(int id);    
        Task<dynamic> GetJobNoByCustomerID(int id); 
    }

}
