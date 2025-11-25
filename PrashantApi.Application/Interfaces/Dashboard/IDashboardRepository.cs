using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrashantApi.Application.DTOs.Dashboard;

namespace PrashantApi.Application.Interfaces.Dashboard
{
    public interface IDashboardRepository
    {
        Task<DashboardResponseDto> GetDashboardAsync();
    }
}

