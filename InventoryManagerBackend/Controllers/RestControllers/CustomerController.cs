using DataAccess;

using DataAccess.Models.Entities;
using DataAccess.Repositories;

namespace InventoryManagerBackend.Controllers.RestControllers;

public class CustomerController : RestControllerBase<Customer, long, CustomerDto>
{
    public CustomerController(ICustomerRepository repository, ICustomerMapper mapper) : base(repository, mapper)
    {
    }

}
