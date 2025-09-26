using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace PrashantApi.Application.Feature.RoleMaster.Commands
{
    public class AddRoleMasterCommand : IRequest<int>
    {
        public string Role { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
