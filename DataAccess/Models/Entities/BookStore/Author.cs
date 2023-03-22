using Mapster;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models.Entities.BookStore
{

    public class Author : IEntity<long>
    {
        public long? Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }

        public List<BookAuthor> AuthorBooks { get; set; } = new();
    }


    public class AuthorDto
    {
        public long? Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string? Email { get; set; }

        public List<long> BookIds { get; set; } = new();
        public List<long> PublisherIds { get; set; } = new();
    }

}
