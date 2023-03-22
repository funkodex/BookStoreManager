using Mapster;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models.Entities
{
    [Index(nameof(Name), IsUnique = true)]

    public class Category : IEntity<long>
    {
        public long? Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string? Color { get; set; }


        public List<Product> Products { get; set; } = new();

        public bool IsBookCategory { get; set; } = false;
    }


    public class CategoryDto
    {
        public long? Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string? Color { get; set; }


        public List<long> ProductIds { get; set; } = new();

        public bool IsBookCategory { get; set; }
    }

}
