using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Domain.Entities.Estimate
{
    public class EstimateMasterModel  
    {
        public int Id { get; set; }
        public int EstimateNo { get; set; }
        public int JobNo { get; set; }
        public DateTime EstimateDate { get; set; }
        public int EstimatedCustomer { get; set; } 
        public string? Remarks { get; set; }
        public decimal EstimatedLabour { get; set; }
        public decimal TransportCharges { get; set; }
        public decimal TotalEstimate { get; set; }
        public bool IsApproved { get; set; }
        public DateTime ApprovalDate { get; set; }
        public string? ApprovedBy { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; } 
        public int ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public List<EstimatedPartDetailsModel> Items { get; set; } = new();
    }

    public class EstimatedPartDetailsModel
    { 
        public int EstimatedId { get; set; }
        public string? ItemId { get; set; }
        public decimal PricePerItem { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
