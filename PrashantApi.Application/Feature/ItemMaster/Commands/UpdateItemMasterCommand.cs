using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Application.Feature.ItemMaster.Commands
{
    public class UpdateItemMasterCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string ItemCode { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public decimal OpeningStock { get; set; }
        public DateTime? OpeningStockAsOn { get; set; }
        public decimal ItemStock { get; set; }
        public decimal PerUnitPrice { get; set; }
        public string ModifiedBy { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public int? LedgerId { get; set; }
    }
}
