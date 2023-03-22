using Audit.EntityFramework;
using Mapster;

namespace DataAccess.Models.Entities
{

    public class Product : IEntity<long>
    {
        public long? Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public int Quantity { get; set; }

        public decimal CostPrice { get; set; }

        public decimal Markup { get; set; }

        public decimal RetailPrice { get; set; }

        public decimal? WholeSalePrice { get; set; }

        public string? Color { get; set; }
        public string? ImageUrl { get; set; }

        public string? Placement { get; set; }

        public long? CategoryId { get; set; }
        public Category? Category { get; set; }

        public string? Barcode { get; set; }
        public string? QrCode { get; set; }
        public List<ProductSupplier> ProductSuppliers { get; set; } = new();

        public List<Tag>? Tags { get; set; }


    }

    public class GenericProduct : Product
    {

    }

    public class ProductDto
    {
        public long? Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public int Quantity { get; set; }

        public decimal CostPrice { get; set; }

        public decimal Markup { get; set; }

        public decimal RetailPrice { get; set; }

        public decimal? WholeSalePrice { get; set; }

        public string? Placement { get; set; }

        public string? Color { get; set; }
        public string? ImageUrl { get; set; }

        public long? CategoryId { get; set; }

        public List<long> SupplierIds { get; set; } = new();

        public string? Barcode { get; set; }
        public string? QrCode { get; set; }

        public List<Tag>? Tags { get; set; }


    }
}
