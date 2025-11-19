using System;
using System.Collections.Generic;

namespace PrashantApi.Domain.Entities.InvoiceMaster
{
    public class InvoiceMasterModel
    {
        public int Id { get; set; }
        public int InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int CustomerId { get; set; }      
        public decimal GstPercent { get; set; }
        public decimal GstAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        //public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
       // public DateTime ModifiedOn { get; set; }
        public decimal TransportCharges { get; set; }
        public int Discount { get; set; }


        public List<InvoiceJobDetailsModel> JobDetails { get; set; } = new();
       
    }
}
