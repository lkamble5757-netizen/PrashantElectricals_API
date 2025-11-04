using Microsoft.AspNetCore.Http.HttpResults;
using PrashantApi.Application.DTOs.CommonDTO;
using System;
using System.Collections.Generic;

namespace PrashantApi.Application.DTOs.RepairWork
{
    public class RepairWorkDto : BaseDTO
    {
        public int Id { get; set; }
        public int RepairWorkNo { get; set; }
        public int jobNo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string WorkDone { get; set; } = string.Empty;
        public List<RepairWorkItemDto> Items { get; set; } = new();
        public decimal LabourCharges { get; set; }
        public int totalrepairwork { get; set; }
        public int Status { get; set; }

    }

    public class RepairWorkItemDto : BaseDTO
    {

        public int Id { get; set; }
        public int RepairWorkId { get; set; }
        public int ItemId { get; set; }
        public int itemQty { get; set; }
        public decimal pricePerItem { get; set; }
        public int total { get; set; }


    }
}
