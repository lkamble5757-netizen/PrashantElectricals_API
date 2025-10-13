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
        public string JobNo { get; set; } = string.Empty;
        public DateTime EstimateDate { get; set; }
        public int EstimatedCustomer { get; set; } 
        public string? Remarks { get; set; }
        public decimal EstimatedLabour { get; set; }
        public decimal TransportCharges { get; set; }
        public decimal TotalEstimate { get; set; }
        public bool IsApproved { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string? ApprovedBy { get; set; }
        public bool IsActive { get; set; }
        public int? CreatedBy { get; set; } 
        public string? ModifiedBy { get; set; } 

        public List<EstimatedPartDetailsModel> Items { get; set; } = new();
    }

    public class EstimatedPartDetailsModel
    { 
        public int EstimatedId { get; set; }
        public int ItemId { get; set; }
        public decimal PricePerItem { get; set; }
        public int ItemQty { get; set; } 
        public int Total { get; set; } 
    }
}
