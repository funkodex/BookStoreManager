namespace DataAccess.Models.Entities
{
    public class OrderItem
    {
        public long? Id { get; set; }

        public long? ProductId { get; set; }
        public Product? Product { get; set; }
        public bool IsBook { get; set; }
        public int Quantity { get; set; }

    }




}
