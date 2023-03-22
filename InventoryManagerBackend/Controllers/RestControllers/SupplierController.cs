using DataAccess;

using DataAccess.Models.Entities;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace InventoryManagerBackend.Controllers.RestControllers;
[AllowAnonymous]
public class SupplierController : RestControllerBase<Supplier, long, SupplierDto>
{
    public SupplierController(ISupplierRepository repository, ISupplierMapper mapper) : base(repository, mapper)
    {
    }

}
