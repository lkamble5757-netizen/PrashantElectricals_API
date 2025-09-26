using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace PrashantApi.Application.Feature.RoleWiseMenuMaster.Commands
{
    public class UpdateRoleWiseMenuMasterCommand : IRequest
    {
        public int Id { get; set; }
        //public List<int> MenuId { get; set; } = new List<int>(); // Multiple roles
        public List<int> MenuId { get; set; } = new(); // Multiple roles
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
        public bool IsObsolete { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
