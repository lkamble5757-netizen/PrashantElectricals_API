using PrashantApi.Application.DTOs.CommonDTO;
using System;
using System.Collections.Generic;

namespace PrashantApi.Application.DTOs.ChallanMaster
{
    public class ChallanMasterDto : BaseDTO
    {
        public int Id { get; set; }
        public int ChallanNo { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public List<ChallanDetailsDto> Details { get; set; } = new();
    }

    public class ChallanDetailsDto : BaseDTO
    {
        public int Id { get; set; }
        public int ChallanId { get; set; }
        public int InvoiceId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
