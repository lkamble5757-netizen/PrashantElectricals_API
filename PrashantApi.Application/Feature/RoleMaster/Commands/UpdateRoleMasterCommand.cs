using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace PrashantApi.Application.Feature.RoleMaster.Commands
{
    public class UpdateRoleMasterCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Role { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ModifiedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
