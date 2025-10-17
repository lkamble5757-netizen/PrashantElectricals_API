using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrashantApi.Domain.Entities.RepairWork
{
    public class RepairWorkModel
    {
        public int Id { get; set; }
        public int jobNo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string WorkDone { get; set; } = string.Empty;
        public decimal LabourCharges { get; set; }
        public int totalrepairwork { get; set; }
        public int Status { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }

        public List<RepairWorkItemModel> Items { get; set; } = new();
    }
}
