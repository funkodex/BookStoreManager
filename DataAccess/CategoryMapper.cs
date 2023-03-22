//using DataAccess.Models.Dtos;

using DataAccess.Models.Entities;

namespace DataAccess.Mappers
{
    public class CategoryMapper : ICategoryMapper
    {
        public Category MapToEntity(CategoryDto dto)
        {
            return new()
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Color = dto.Color,
                IsBookCategory = dto.IsBookCategory,
                Products = dto.ProductIds.Select(id => new Product() { Id = id }).ToList()
            };
        }

        public CategoryDto MapToDto(Category obj)
        {
            return new()
            {
                Id = obj.Id,
                Name = obj.Name,
                Description = obj.Description,
                Color = obj.Color,
                IsBookCategory = obj.IsBookCategory,
                ProductIds = obj.Products.Select(p => p.Id.Value).ToList()
            };
        }

        public CategoryDto MapToExistingDto(Category obj, CategoryDto dto)
        {
            dto.Id = obj.Id;
            dto.Name = obj.Name;
            dto.Description = obj.Description;
            dto.Color = obj.Color;
            dto.IsBookCategory = obj.IsBookCategory;
            dto.ProductIds = obj.Products.Select(p => p.Id.Value).ToList();
            return dto;
        }

        public void MapToExistingEntity(CategoryDto dto, Category entity)
        {
            throw new NotImplementedException();
        }
    }
}