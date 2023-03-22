using DataAccess;

using DataAccess.Models.Entities;
using DataAccess.Repositories;

namespace InventoryManagerBackend.Controllers.RestControllers
{
    public class BundleController : RestControllerBase<Bundle, long, BundleDto>
    {
        public BundleController(IBundleRepository repository, IBundleMapper mapper) : base(repository, mapper)
        {
        }
    }
}