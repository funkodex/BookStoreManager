using DataAccess;

using DataAccess.Models.Entities.BookStore;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagerBackend.Controllers.RestControllers;

public class BookController : RestControllerBase<Book, long, BookDto>
{
    public BookController(IBookRepository repository, IBookMapper mapper) : base(repository, mapper)
    {
    }

    public override async Task<ActionResult<BookDto>> Update(long id, BookDto dto)
    {
        var entity = await _repository.FindByIdIncludingAsync(id,"ProductSuppliers","BookAuthors");
        if (entity is null)
        {
            return NotFound();
        }

        _mapper.MapToExistingEntity(dto, entity);
        await _repository.UpdateAsync(entity);
        // ReSharper disable once HeapView.PossibleBoxingAllocation
        return Ok(_mapper.MapToExistingDto(entity, dto));
    }
}