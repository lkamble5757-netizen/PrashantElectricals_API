using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrashantApi.Application.DTOs.CustomerMaster;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Application.Feature.CustomerMaster.Commands
{
    public class AddCustomerMasterCommand : IRequest<CommandResult>
    {
        public CustomerMasterDto Customer { get; set; } = default!;
    }
}