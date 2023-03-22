namespace DataAccess.Models.Entities
{
    public class OrderItemDto
    {
        public long? Id { get; set; }

        public long? ProductId { get; set; }
        public bool IsBook { get; set; }
        public int Quantity { get; set; }
    }




}
