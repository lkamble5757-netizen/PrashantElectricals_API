using PrashantApi.Application.DTOs.CommonDTO;
using System;
using System.Collections.Generic;

namespace PrashantApi.Application.DTOs.InvoiceMaster
{
    public class InvoiceMasterDto : BaseDTO

    {
        public int Id { get; set; }
        public int InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int? CustomerId { get; set; }
        public decimal GstPercent { get; set; }
        public decimal GstAmount { get; set; }
        public decimal TotalAmount { get; set; }
        //public DateTime CreatedOn { get; set; }
        //public DateTime ModifiedOn { get; set; }
        public decimal TransportCharges { get; set; }
        public int Discount { get; set; }
        public List<InvoiceJobDetailsDto> JobDetails { get; set; } = new();
       
    }

    public class InvoiceJobDetailsDto : BaseDTO
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int? JobId { get; set; }
        public string WorkDone { get; set; } = string.Empty;
        public decimal Total { get; set; }
        //public List<InvoiceItemDetailsDto> ItemDetails { get; set; } = new();
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }

    public class InvoiceItemDetailsDto : BaseDTO
    {
        public int Id { get; set; }
        public int InvoiceDetailId { get; set; }
        public int InvoiceId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public string ItemQty { get; set; } = string.Empty;
        public decimal Total { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

    }
}
