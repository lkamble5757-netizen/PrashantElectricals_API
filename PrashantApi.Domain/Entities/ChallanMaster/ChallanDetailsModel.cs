using System;

namespace PrashantApi.Domain.Entities.ChallanMaster
{
    public class ChallanDetailsModel
    {
        public int Id { get; set; }
        public int ChallanId { get; set; }
        public int InvoiceId { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
