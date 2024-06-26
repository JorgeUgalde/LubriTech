using LubriTech.Model.Item_Information;

namespace LubriTech.Model.WorkOrder_Information
{
    public class WorkOrderLine
    {
        public int Id { get; set; }
        public int WorkOrderId { get; set; }
        public Item item { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }

        public WorkOrderLine() { }

        public WorkOrderLine(int id, int workOrderId, Item item, decimal quantity, decimal amount, int recommendedMileage)
        {
            this.Id = id;
            this.WorkOrderId = workOrderId;
            this.item = item;
            this.Quantity = quantity;
            this.Amount = amount;
        }

        public override string ToString()
        {
            return $"{Id} - {item.name} - Quantity: {Quantity} - Amount: {Amount}";
        }
    }
}
