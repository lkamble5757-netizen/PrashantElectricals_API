using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Application.DTOs.RoleWiseMenuMaster
{
    public class RoleWiseMenuMasterDto
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        //public List<int> MenuId { get; set; } = new List<int>();
        public List<int> MenuId { get; set; } = new();
        public bool IsActive { get; set; }
        public bool IsObsolete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
