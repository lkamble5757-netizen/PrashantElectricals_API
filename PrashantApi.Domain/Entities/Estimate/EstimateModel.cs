using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Domain.Entities.Estimate
{
    public class EstimateModel
    {
        public int Id { get; set; }
        public string JobNo { get; set; } = string.Empty;
        public DateTime EstimateDate { get; set; }
        public string EstimatedUser { get; set; } = string.Empty;
        public string? Remarks { get; set; }
        public decimal EstimatedParts { get; set; }
        public decimal EstimatedLabour { get; set; }
        public decimal TransportCharges { get; set; }
        public decimal TotalEstimate { get; set; }
        public bool IsApproved { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string? ApprovedBy { get; set; }
        public bool IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
