//using DataAccess.Models.Dtos;

using DataAccess.Models.Entities;

namespace DataAccess.Mappers
{
    public class BundleMapper : IBundleMapper
    {
        public BundleDto MapToDto(Bundle entity)
        {
            return new()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Color = entity.Color,
                ImageUrl = entity.ImageUrl,
                Items = entity.Items.Select(ItemToItemDto).ToList()
            };
        }

        

        public Bundle MapToEntity(BundleDto dto)
        {
            return new()
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Color = dto.Color,
                ImageUrl = dto.ImageUrl,
                Items = dto.Items.Select(ItemDtoToItem).ToList()
            };
        }

        public BundleDto MapToExistingDto(Bundle entity, BundleDto dto)
        {
            dto.Id = entity.Id;
            dto.Name = entity.Name;
            dto.Description = entity.Description;
            dto.Color = entity.Color;
            dto.ImageUrl = entity.ImageUrl;
            dto.Items = entity.Items.Select(ItemToItemDto).ToList();
            return dto;
        }

        public void MapToExistingEntity(BundleDto dto, Bundle entity)
        {
            entity.Id = dto.Id;
            entity.Name = dto.Name;
            entity.Description = dto.Description;
            entity.Color = dto.Color;
            entity.ImageUrl = dto.ImageUrl;
            entity.Items = dto.Items.Select(ItemDtoToItem).ToList();
        }


        private BundleItemDto ItemToItemDto(BundleItem item)
        {
            return new()
            {
                Id = item.Id,
                BundleId = item.BundleId,
                ProductId = item.ProductId,
                IsBook = item.IsBook,
                Quantity = item.Quantity
            };
        }

        private BundleItem ItemDtoToItem(BundleItemDto item)
        {
            return new()
            {
                Id = item.Id,
                BundleId = item.BundleId,
                ProductId = item.ProductId,
                IsBook = item.IsBook,
                Quantity = item.Quantity
            };
        }


    }

}