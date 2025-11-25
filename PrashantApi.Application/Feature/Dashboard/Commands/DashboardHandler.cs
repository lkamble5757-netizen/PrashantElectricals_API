using MediatR;
using PrashantEle.API.PrashantEle.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrashantApi.Application.DTOs.Dashboard;
using PrashantApi.Application.Interfaces.Dashboard;

namespace PrashantApi.Application.Feature.Dashboard.Commands
{
    public class DashboardHandler : IRequestHandler<DashboardCommand, CommandResult>
    {
        private readonly IDashboardRepository _repo;

        public DashboardHandler(IDashboardRepository repo)
        {
            _repo = repo;
        }

        public async Task<CommandResult> Handle(DashboardCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _repo.GetDashboardAsync();
                return CommandResult.SuccessWithOutput(data);
            }
            catch (Exception ex)
            {
                return CommandResult.Fail($"Failed to load dashboard: {ex.Message}");
            }
        }
    }
}

