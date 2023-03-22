namespace DataAccess.Models.Entities
{
    public class SalesOrderDto : OrderDto
    {
        public List<SalesOrderItemDto> Items { get; set; } = new();
        public int? OrderNumber { get; set; }
        public long? CustomerId { get; set; }
        public decimal Total { get; set; }
    }


}
