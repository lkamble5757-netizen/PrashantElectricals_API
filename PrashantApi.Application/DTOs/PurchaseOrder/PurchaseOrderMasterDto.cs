using System;
using System.Collections.Generic;
using PrashantApi.Application.DTOs.CommonDTO;

namespace PrashantApi.Application.DTOs.PurchaseOrder
{
    public class PurchaseOrderMasterDto : BaseDTO
    {
        public int Id { get; set; }
        public string PurchaseOrderNo { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsActive { get; set; }

        public List<PurchaseOrderDetailsDto> Items { get; set; } = new();
    }

    public class PurchaseOrderDetailsDto : BaseDTO
    {
        public int Id { get; set; }
        public int PurchaseOrderId { get; set; }
        public int ItemId { get; set; }
        public decimal PricePerItem { get; set; }
        public decimal Quantity { get; set; }
        public string UnitType { get; set; } = string.Empty;
        public decimal Total { get; set; }
        public bool IsActive { get; set; }
    }
}
