using DataAccess;
using DataAccess.Models.Entities;
using DataAccess.Repositories;

namespace InventoryManagerBackend.Controllers.RestControllers;

public class ProductController : RestControllerBase<GenericProduct, long, ProductDto>
{
    public ProductController(IProductRepository repository, IProductMapper mapper) : base(repository, mapper)
    {
    }
}