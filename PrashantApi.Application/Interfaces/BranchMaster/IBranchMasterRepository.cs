using PrashantApi.Application.DTOs.BranchMaster;
using PrashantApi.Domain.Entities.BranchMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace PrashantApi.Application.Interfaces.BranchMaster
{
    public interface IBranchMasterRepository
    {
        Task<int> AddAsync(BranchMasterModel entity);
        Task<BranchMasterModel?> GetByIdAsync(int id);
    }
}
