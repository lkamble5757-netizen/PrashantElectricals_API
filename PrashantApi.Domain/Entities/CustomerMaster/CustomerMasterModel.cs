using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace PrashantApi.Domain.Entities.CustomerMaster
{
    public class CustomerMasterModel
    {
        public int Id { get; set; }
        public string CustName { get; set; } = string.Empty;
        public string? CustEmail { get; set; }
        public string? CustPhoneNo { get; set; }
        public string? CustAddress { get; set; }
        public string? GSTNo { get; set; }
        //public int LedgerCode { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
