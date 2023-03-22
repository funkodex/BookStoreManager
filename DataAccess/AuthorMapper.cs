//using DataAccess.Models.Dtos;

using DataAccess.Models.Entities.BookStore;

namespace DataAccess.Mappers
{
    public partial class AuthorMapper : IAuthorMapper
    {
        public Author MapToEntity(AuthorDto dto)
        {
            return new()
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                AuthorBooks = dto.BookIds.Select(bookId => new BookAuthor { AuthorId = dto.Id,BookId = bookId }).ToList()
            };
        }

        public AuthorDto MapToDto(Author dto)
        {
            return new()
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                BookIds = getBookIds(dto)
            };
        }

        private static List<long> getBookIds(Author dto)
        {
            return dto.AuthorBooks.Where(b => b.BookId is not null).Select(b => b.BookId.Value).ToList();
        }

        public AuthorDto MapToExistingDto(Author obj, AuthorDto dto)
        {
            dto.Id = obj.Id;
            dto.FirstName = obj.FirstName;
            dto.LastName = obj.LastName;
            dto.Email = obj.Email;
            dto.BookIds = getBookIds(obj);
            return dto;
        }

        public void MapToExistingEntity(AuthorDto dto, Author entity)
        {
            throw new NotImplementedException();
        }
    }




    public class PublisherMapper : IPublisherMapper
    {
        public PublisherDto MapToDto(Publisher entity)
        {
            return new()
            {
                Id = entity.Id,
                Name = entity.Name,
                Address = entity.Address,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,
            };
        }

        public Publisher MapToEntity(PublisherDto dto)
        {
            return new()
            {
                Id = dto.Id,
                Name = dto.Name,
                Address = dto.Address,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
            };
        }

        public PublisherDto MapToExistingDto(Publisher entity, PublisherDto dto)
        {
            dto.Id = entity.Id;
            dto.Name = entity.Name;
            dto.Address = entity.Address;
            dto.Email = entity.Email;
            dto.PhoneNumber = entity.PhoneNumber;
            return dto;
        }

        public void MapToExistingEntity(PublisherDto dto, Publisher entity)
        {
            entity.Id = dto.Id;
            entity.Name = dto.Name;
            entity.Address = dto.Address;
            entity.Email = dto.Email;
            entity.PhoneNumber = dto.PhoneNumber;
        }
    }

}