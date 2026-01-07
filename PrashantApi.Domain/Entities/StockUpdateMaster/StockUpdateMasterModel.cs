using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Domain.Entities.StockUpdateMaster
{
    public class StockUpdateMasterModel
    {
        public int Id { get; set; }
        public DateTime StockDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public List<StockUpdateDetailsModel> Items { get; set; } = new();
    }
}
