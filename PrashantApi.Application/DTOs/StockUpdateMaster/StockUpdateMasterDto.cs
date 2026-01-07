using PrashantApi.Application.DTOs.CommonDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Application.DTOs.StockUpdateMaster
{
    public class StockUpdateMasterDto : BaseDTO
    {
        public int Id { get; set; }
        public DateTime StockDate { get; set; }
        public bool IsActive { get; set; }

        public List<StockUpdateDetailsDto> Items { get; set; } = new();
    }

    public class StockUpdateDetailsDto : BaseDTO
    {
        public int Id { get; set; }
        public int StockUpdateId { get; set; }
        public int ItemId { get; set; }
        public decimal AvailableStock { get; set; }
        public decimal Usages { get; set; }
        public bool IsActive { get; set; }
    }
}
