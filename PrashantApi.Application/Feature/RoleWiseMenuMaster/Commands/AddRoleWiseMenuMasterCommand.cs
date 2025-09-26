using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace PrashantApi.Application.Feature.RoleWiseMenuMaster.Commands
{
    public class AddRoleWiseMenuMasterCommand : IRequest
    {
        public int  RoleId{ get; set; }
        //public List<int> MenuId { get; set; } = new List<int>(); // Multiple roles
        public List<int> MenuId { get; set; } = new(); // Multiple roles
        public bool IsActive { get; set; } = true;
        public bool IsObsolete { get; set; } = false;
        public string CreatedBy { get; set; } = string.Empty;
    }
}
