using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Domain.Entities.StockUpdateMaster
{
    public class StockUpdateDetailsModel
    {
        public int Id { get; set; }
        public int StockUpdateId { get; set; }
        public int ItemId { get; set; }
        public decimal AvailableStock { get; set; }
        public decimal Usages { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}