namespace DataAccess.Models.Entities
{
    public class PurchaseOrderDto : OrderDto
    {

        public List<PurchaseOrderItemDto> Items { get; set; } = new();
        public long? SupplierId { get; set; }
        public decimal Total { get; set; }
    }


}
