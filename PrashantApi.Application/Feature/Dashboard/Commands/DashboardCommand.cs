using MediatR;
using PrashantEle.API.PrashantEle.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Application.Feature.Dashboard.Commands
{
    public class DashboardCommand : IRequest<CommandResult>
    {
        public int? Year { get; set; }
    }
}
