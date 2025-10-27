using PrashantApi.Application.DTOs.CommonDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Application.DTOs.RoleWiseMenuMaster
{
    public class RoleWiseMenuMasterDto : BaseDTO
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public List<int> MenuId { get; set; } = new();
        public bool IsObsolete { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
