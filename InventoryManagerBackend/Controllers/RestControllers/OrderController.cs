using DataAccess;

using DataAccess.Models.Entities;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagerBackend.Controllers.RestControllers
{

    public class OrderController : RestControllerBase<SalesOrder, long, SalesOrderDto>
    {

        public OrderController(IOrderRepository repository, ISalesOrderMapper mapper) : base(repository, mapper)
        {
        }

        public async override Task<ActionResult<SalesOrderDto>> Create(SalesOrderDto dto)
        {
            var entity = _mapper.MapToEntity(dto);
            var orderCount = _repository.Entities.Where(o => DateOnly.FromDateTime(DateTime.Now) == DateOnly.FromDateTime(o.IssuedDate.Date)).Count() + 1;
            entity.OrderNumber = orderCount;
            try
            {
                await _repository.CreateAsync(entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return CreatedAtAction("Create", new { Id = entity.Id }, _mapper.MapToExistingDto(entity, dto));
        }
        [HttpGet("unprocessed")]
        public async Task<ActionResult<List<SalesOrderDto>>> GetAllUnprocessedAsync()
        {
            var orders = await _repository.Entities.Include("Items.Product").Include(x => x.Payment).Where(x => x.Payment == null).ToListAsync();
            var all = await _repository.Entities.Include("Items.Product").Include(x => x.Payment).ToListAsync();
            return Ok(orders.Select(_mapper.MapToDto).ToList());
        }
    }

    
}