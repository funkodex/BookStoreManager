using DataAccess;
using DataAccess.Models.Entities.BookStore;
using DataAccess.Repositories;

namespace InventoryManagerBackend.Controllers.RestControllers;

public class PublisherController : RestControllerBase<Publisher, long, PublisherDto>
{
    public PublisherController(IPublisherRepository repository, IPublisherMapper mapper) : base(repository, mapper)
    {
    }

}