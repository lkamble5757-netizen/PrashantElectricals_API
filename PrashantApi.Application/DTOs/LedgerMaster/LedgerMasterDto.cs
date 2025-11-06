using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrashantApi.Application.DTOs.CommonDTO;
using System;

namespace PrashantApi.Application.DTOs.LedgerMaster
{
    public class LedgerMasterDto : BaseDTO
    {
        public int Id { get; set; }
        public int LedgerCode { get; set; }
        public string LedgerName { get; set; } = string.Empty;
        public int MainGroupId { get; set; }
        public int SubGroup1Id { get; set; }
        public int SubGroup2Id { get; set; }
        public int SubGroup3Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}

