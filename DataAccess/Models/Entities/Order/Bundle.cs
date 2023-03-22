namespace DataAccess.Models.Entities
{
    public class Bundle: IEntity<long>
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? Color { get; set; }

        public List<BundleItem> Items { get; set; } = new();
    }

    public class BundleDto 
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? Color { get; set; }

        public List<BundleItemDto> Items { get; set; } = new();
    }

}
