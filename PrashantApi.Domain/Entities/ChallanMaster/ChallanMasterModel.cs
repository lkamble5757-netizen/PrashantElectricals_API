using System;
using System.Collections.Generic;

namespace PrashantApi.Domain.Entities.ChallanMaster
{
    public class ChallanMasterModel
    {
        public int Id { get; set; }
        public int ChallanNo { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }

        public List<ChallanDetailsModel> Details { get; set; } = new();
    }
}
