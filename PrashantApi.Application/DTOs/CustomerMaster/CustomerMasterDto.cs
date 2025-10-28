using PrashantApi.Application.DTOs.CommonDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Application.DTOs.CustomerMaster
{
    public class CustomerMasterDto : BaseDTO
    {
        public int Id { get; set; }
        public string CustName { get; set; } = string.Empty;
        public string? CustEmail { get; set; }
        public string? CustPhoneNo { get; set; }
        public string? CustAddress { get; set; }
        public string? GSTNo { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
