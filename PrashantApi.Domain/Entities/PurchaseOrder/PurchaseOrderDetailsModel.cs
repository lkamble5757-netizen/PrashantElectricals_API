using System;

namespace PrashantApi.Domain.Entities.PurchaseOrder
{
    public class PurchaseOrderDetailsModel
    {
        public int Id { get; set; }
        public int PurchaseOrderId { get; set; }
        public int ItemId { get; set; }
        public decimal PricePerItem { get; set; }
        public decimal Quantity { get; set; }
        public string UnitType { get; set; } = string.Empty;
        public decimal Total { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
