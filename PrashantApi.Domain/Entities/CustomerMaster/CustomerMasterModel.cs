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
        public int Cust_Id { get; set; }
        public string Cust_Name { get; set; } = string.Empty;
        public string? Cust_Email { get; set; }
        public string? Cust_PhoneNo { get; set; }
        public string? Cust_Address { get; set; }
        public string? GSTNo { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
