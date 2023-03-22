//using DataAccess.Models.Dtos;

using DataAccess.Models.Entities;

namespace DataAccess.Mappers
{
    public class ProductMapper : IProductMapper
    {
        public GenericProduct MapToEntity(ProductDto dto)
        {
            return new()
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Quantity = dto.Quantity,
                CostPrice = dto.CostPrice,
                Markup = dto.Markup,
                RetailPrice = dto.RetailPrice,
                WholeSalePrice = dto.WholeSalePrice,
                Color = dto.Color,
                ImageUrl = dto.ImageUrl,
                CategoryId = dto.CategoryId,
                Tags = dto.Tags,
                Barcode = dto.Barcode,
                QrCode = dto.QrCode
            };
        }

        public ProductDto MapToDto(GenericProduct entity)
        {
            return new()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Quantity = entity.Quantity,
                CostPrice = entity.CostPrice,
                Markup = entity.Markup,
                RetailPrice = entity.RetailPrice,
                WholeSalePrice = entity.WholeSalePrice,
                Color = entity.Color,
                ImageUrl = entity.ImageUrl,
                CategoryId = entity.CategoryId,
                Tags = entity.Tags,
                 Barcode = entity.Barcode,
                QrCode = entity.QrCode
            };
        }

        public ProductDto MapToExistingDto(GenericProduct entity, ProductDto dto)
        {
            dto.Id = entity.Id;
            dto.Name = entity.Name;
            dto.Description = entity.Description;
            dto.Quantity = entity.Quantity;
            dto.CostPrice = entity.CostPrice;
            dto.Markup = entity.Markup;
            dto.RetailPrice = entity.RetailPrice;
            dto.WholeSalePrice = entity.WholeSalePrice;
            dto.Color = entity.Color;
            dto.ImageUrl = entity.ImageUrl;
            dto.CategoryId = entity.CategoryId;
            dto.Tags = entity.Tags;
            dto.Barcode = entity.Barcode;
            dto.QrCode = entity.QrCode;
            return dto;
        }

        public void MapToExistingEntity(ProductDto dto, GenericProduct entity)
        {
            throw new NotImplementedException();
        }
    }

}