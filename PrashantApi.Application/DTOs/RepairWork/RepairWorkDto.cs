using System;
using System.Collections.Generic;

namespace PrashantApi.Application.DTOs.RepairWork
{
    public class RepairWorkDto
    {
        public int Id { get; set; }
        public int jobNo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string WorkDone { get; set; } = string.Empty;
        public List<RepairWorkItemDto> Items { get; set; } = new();
        public decimal LabourCharges { get; set; }
        public int totalrepairwork { get; set; }
        public int Status { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }

    public class RepairWorkItemDto
    {

        public int RepairWorkId { get; set; }
        public int ItemId { get; set; }
        public string itemQty { get; set; }
        public decimal pricePerItem { get; set; }
        public decimal total { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

    }
}
