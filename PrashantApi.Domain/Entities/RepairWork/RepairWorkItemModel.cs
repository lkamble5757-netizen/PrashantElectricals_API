
namespace PrashantApi.Domain.Entities.RepairWork
{
    public class RepairWorkItemModel
    {
        public int Id { get; set; }
        public int RepairWorkId { get; set; }
        public int ItemId { get; set; }
        public int itemQty { get; set; }
        public decimal pricePerItem { get; set; }
        public int total { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
