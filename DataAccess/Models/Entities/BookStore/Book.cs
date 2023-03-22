using Mapster;

namespace DataAccess.Models.Entities.BookStore
{
    public class Book : Product
    {
        public int Edition { get; set; }
        public int Year { get; set; }

        public List<BookAuthor> BookAuthors { get; set; } = new();
        public long? PublisherId { get; set; }
        public Publisher? Publisher { get; set; }
    }

    public class BookDto : ProductDto
    {
        public int Edition { get; set; }
        public int Year { get; set; }

        public List<long> AuthorIds { get; set; } = new();
        public long? PublisherId { get; set; }

    }

}
