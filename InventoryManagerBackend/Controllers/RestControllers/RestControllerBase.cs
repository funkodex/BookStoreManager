using DataAccess;

using DataAccess.Models.Entities;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagerBackend.Controllers.RestControllers;
[Route("api/[controller]")]
[ApiController]
[EnableCors("allowedOrigin")]
public abstract class RestControllerBase<TEntity, TId, TDto> : ControllerBase where TEntity : class, IEntity<TId> where TId : struct
{
    protected readonly IRepository<TEntity, TId> _repository;
    protected readonly IMapper<TEntity, TDto> _mapper;

    protected RestControllerBase(IRepository<TEntity, TId> repository, IMapper<TEntity, TDto> mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }




    [HttpGet]
    public virtual async Task<ActionResult<List<TDto>>> GetAllAsync()
    {
        var categories = await _repository.FindAllAsync();
        return Ok(categories.Select(_mapper.MapToDto).ToList());
    }

    [HttpPost("including")]

    public virtual async Task<ActionResult<List<TDto>>> GetAllIncludingAsync(string[] relations)
    {
        var entities = await _repository.FindAllIncludingAsync(relations);
        var dtos = entities.Select(_mapper.MapToDto).ToList();
        return Ok(dtos);
    }


    [HttpGet("{id}")]
    public virtual async Task<ActionResult<TDto>> GetAsync(TId id)
    {
        var entity = await _repository.FindByIdAsync(id);
        if (entity == null)
        {
            return NotFound();
        }

        // ReSharper disable once HeapView.PossibleBoxingAllocation
        return Ok(_mapper.MapToDto(entity));
    }

    [HttpPost]
    public virtual async Task<ActionResult<TDto>> Create(TDto dto)
    {
        var entity = _mapper.MapToEntity(dto);
        try
        {
            await _repository.CreateAsync(entity);
        }
        catch (Exception e)
        {

        }

        return CreatedAtAction("Create", new { Id = entity.Id }, _mapper.MapToExistingDto(entity, dto));
    }

    [HttpPut("{id}")]
    public virtual async Task<ActionResult<TDto>> Update(TId id, TDto dto)
    {
        var exists = await _repository.ExistsByIdAsync(id);
        if (!exists)
        {
            return NotFound();
        }

        var entity = _mapper.MapToEntity(dto);
        await _repository.UpdateAsync(entity);
        // ReSharper disable once HeapView.PossibleBoxingAllocation
        return Ok(_mapper.MapToExistingDto(entity, dto));
    }

    [HttpDelete("{id}")]
    public virtual async Task<ActionResult> Delete(TId id)
    {
        var entity = await _repository.FindByIdAsync(id);
        if (entity == null)
        {
            return NotFound();
        }
        await _repository.DeleteAsync(entity);
        return Ok();
    }

    [HttpDelete()]
    public virtual async Task<ActionResult> DeleteMany(List<TId> ids)
    {
        var count = await _repository.DeleteManyAsync(ids);
        return Ok(new {count});
    }
}