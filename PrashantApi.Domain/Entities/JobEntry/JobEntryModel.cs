using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Domain.Entities.JobEntry
{
    public class JobEntryModel
    {
        public int ID { get; set; }
        public int JobNo { get; set; } 
        public DateTime DateReceived { get; set; }
        public int CustomerID { get; set; }
        public string? CustomerName { get; set; }
        public string? MachineMake { get; set; }
        public int Model { get; set; }
        public int HpKw { get; set; }
        public int RPM { get; set; }
        public string? SerialNo { get; set; }
        public string? IssueReported { get; set; }
        public string? TechnicianAssigned { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
        public int Status { get; set; }
        public string? Attachments { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
