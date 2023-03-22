using DataAccess;
using DataAccess.Models.Dtos;
using DataAccess.Models.Entities;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace InventoryManagerBackend.Controllers.RestControllers;
//[Authorize]
public class PaymentController : RestControllerBase<Payment, long, PaymentDto>
{
    public PaymentController(IPaymentRepository repository, IPaymentMapper mapper) : base(repository, mapper)
    {
    }
}