using PrashantApi.Application.DTOs.CommonDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Application.DTOs.RoleMaster
{
    public class RoleMasterDto : BaseDTO
    {
        public int Id { get; set; }
        public string Role { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
