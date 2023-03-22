using DataAccess;

using DataAccess.Models.Entities.BookStore;
using DataAccess.Repositories;

namespace InventoryManagerBackend.Controllers.RestControllers;

public class AuthorController : RestControllerBase<Author, long, AuthorDto>
{
    public AuthorController(IAuthorRepository repository, IAuthorMapper mapper) : base(repository, mapper)
    {
    }
}