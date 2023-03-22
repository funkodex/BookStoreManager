using Mapster;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models.Entities.BookStore
{
    [Table("publishers")]
    public class Publisher : IEntity<long>
    {
        public long? Id { get; set; }
        public string Name { get; set; }

        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        List<Book> Books { get; set; } = new();
    }


    public class PublisherDto
    {
        public long? Id { get; set; }
        public string Name { get; set; }

        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        List<long> AuthorIds { get; set; } = new();
        List<long> BookIds { get; set; } = new();
    }

}
