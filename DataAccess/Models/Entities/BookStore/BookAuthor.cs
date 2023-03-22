namespace DataAccess.Models.Entities.BookStore
{
    public class BookAuthor
    {
        public long? BookId { get; set; }
        public long? AuthorId { get; set; }
        public Book? Book { get; set; }
        public Author? Author { get; set; }
    }

}
