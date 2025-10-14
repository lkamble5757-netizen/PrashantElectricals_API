
namespace PrashantApi.Domain.Entities.RepairWork
{
    public class RepairWorkItemModel
    {
        public int Id { get; set; }
        public int RepairWorkId { get; set; }
        public int ItemId { get; set; }
        public string itemQty { get; set; }
        public decimal PricePerItem { get; set; }
        public decimal Total { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? ModifiedBy { get; set; } = null;
        public DateTime? ModifiedOn { get; set; }
        
    }
}
