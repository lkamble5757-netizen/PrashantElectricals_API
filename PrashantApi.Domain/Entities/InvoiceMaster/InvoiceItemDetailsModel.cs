using System;

namespace PrashantApi.Domain.Entities.InvoiceMaster
{
    public class InvoiceItemDetailsModel
    {
        public int Id { get; set; }
        public int InvoiceDetailId { get; set; }
        public int InvoiceId { get; set; }
        public int ItemId { get; set; }
        public string ItemQty { get; set; } = string.Empty;
        public decimal Total { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
