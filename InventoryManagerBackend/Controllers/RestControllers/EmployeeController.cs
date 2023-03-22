using DataAccess;
using DataAccess.Models.Entities;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagerBackend.Controllers.RestControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : RestControllerBase<Employee, long, EmployeeDto>
    {
        private readonly IEmployeeShiftRepository employeeShiftRepository;

        public EmployeeController(IEmployeeRepository repository, IEmployeeShiftRepository employeeShiftRepository, IEmployeeMapper mapper) : base(repository, mapper)
        {
            this.employeeShiftRepository = employeeShiftRepository;
        }

        [HttpGet("{id}/shifts")]
        async Task<ActionResult<List<EmployeeShift>>> getShifts(long id )
        {
           var shifts  = await employeeShiftRepository.Entities.Where(s=>s.Employee.Id == id).Include(nameof(EmployeeShift.Entries)).ToListAsync();
            return Ok(shifts);
        }
    }
}
