using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace PrashantApi.Application.Feature.ItemMaster.Commands
{
    public class AddItemMasterCommand : IRequest<int>
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public decimal OpeningStock { get; set; }
        public DateTime OpeningStockAsOn { get; set; }
        public decimal ItemStock { get; set; }
        public decimal PerUnitPrice { get; set; }
        public string CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public int LedgerId { get; set; }
        public string HsnNo { get; set; }
    }
}

