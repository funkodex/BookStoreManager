using DataAccess;

using DataAccess.Models.Entities;
using DataAccess.Repositories;

namespace InventoryManagerBackend.Controllers.RestControllers
{
    public class PurchaseController : RestControllerBase<PurchaseOrder, long, PurchaseOrderDto>
    {
        public PurchaseController(IPurchaseRepository repository, IPurchaseOrderMapper mapper) : base(repository, mapper)
        {
        }
    }
}