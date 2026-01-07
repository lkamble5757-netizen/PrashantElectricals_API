using System;
using System.Collections.Generic;

namespace PrashantApi.Domain.Entities.PurchaseOrder
{
    public class PurchaseOrderMasterModel
    {
        public int Id { get; set; }
        public string PurchaseOrderNo { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsActive { get; set; }

        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public List<PurchaseOrderDetailsModel> Items { get; set; } = new();
    }
}

