namespace DataAccess.Models.Entities
{
    public class BundleItem
    {
        public long? Id { get; set; }
        public int Quantity { get; set; }
        public long? ProductId { get; set; }
        public Product? Product { get; set; }
        public bool IsBook { get; set; }

        public long? BundleId { get; set; }
        public Bundle? Bundle { get; set; }
    }

    public class BundleItemDto
    {
        public long? Id { get; set; }
        public int Quantity { get; set; }
        public long? ProductId { get; set; }
        public bool IsBook { get; set; }
        public long? BundleId { get; set; }

    }

}
