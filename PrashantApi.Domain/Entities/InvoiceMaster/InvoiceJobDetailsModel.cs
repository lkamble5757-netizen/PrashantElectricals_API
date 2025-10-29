using System;

namespace PrashantApi.Domain.Entities.InvoiceMaster
{
    public class InvoiceJobDetailsModel
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int? JobId { get; set; }
        public string WorkDone { get; set; } = string.Empty;
        public decimal Total { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        //public List<InvoiceItemDetailsModel> ItemDetails { get; set; } = new();
    }
}
