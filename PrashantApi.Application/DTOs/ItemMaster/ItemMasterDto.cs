using PrashantApi.Application.DTOs.CommonDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Application.DTOs.ItemMaster
{
    public class ItemMasterDto : BaseDTO
    {
        public int Id { get; set; }
        public string ItemCode { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        //public int SubCategoryId { get; set; }
        //public decimal OpeningStock { get; set; }
        //public DateTime OpeningStockAsOn { get; set; }
        //public decimal ItemStock { get; set; }
        public decimal PerUnitPrice { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        //public int LedgerId { get; set; }
        public required string HsnNo { get; set; }
    }
}

