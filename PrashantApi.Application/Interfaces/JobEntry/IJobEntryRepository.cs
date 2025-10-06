using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrashantApi.Domain.Entities.JobEntry;
using PrashantEle.API.PrashantEle.Application.Common;                                       

namespace PrashantApi.Application.Interfaces.JobEntry
{
    public interface IJobEntryRepository
    {
        Task<CommandResult> AddAsync(JobEntryModel entity);
        Task<CommandResult> UpdateAsync(JobEntryModel entity);
        Task<IEnumerable<JobEntryModel>> GetAllAsync();
        Task<IEnumerable<JobEntryModel>> GetByIdAsync(int id);
    }

}
