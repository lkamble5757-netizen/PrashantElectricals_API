using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrashantApi.Application.DTOs.JobEntry;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Application.Interfaces
{
    public interface IJobEntryService
    {
        Task<CommandResult> AddAsync(JobEntryDto dto);
        Task<CommandResult> UpdateAsync(JobEntryDto dto);
        Task<dynamic> GetAllAsync();
        Task<dynamic> GetByIdAsync(int id);

    }
}
