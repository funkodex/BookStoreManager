using DataAccess;

using DataAccess.Models.Entities;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagerBackend.Controllers.RestControllers;


public class CategoryController : RestControllerBase<Category, long, CategoryDto>
{
    public CategoryController(ICategoryRepository repository, ICategoryMapper mapper) : base(repository, mapper)
    {
    }
}