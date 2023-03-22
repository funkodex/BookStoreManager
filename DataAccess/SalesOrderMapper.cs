//using DataAccess.Models.Dtos;

using DataAccess.Models.Entities;

namespace DataAccess.Mappers
{
    public class SalesOrderMapper : ISalesOrderMapper
    {
        public SalesOrder MapToEntity(SalesOrderDto dto)
        {
            return new()
            {
                Id = dto.Id,
                OrderNumber = dto.OrderNumber,
                Total = dto.Total,
                IssuedDate = dto.IssuedDate,
                Items = dto.Items.Select(DtoToOrderItem).ToList(),
                CustomerId = dto.CustomerId
            };
        }

        public SalesOrderDto MapToDto(SalesOrder entity)
        {
            return new()
            {
                Id = entity.Id,
                OrderNumber = entity.OrderNumber,
                Total = entity.Total,
                IssuedDate = entity.IssuedDate,
                Items = entity.Items.Select(EntityToOrderItemDto).ToList(),
                CustomerId = entity.CustomerId
            };
        }

        public SalesOrderDto MapToExistingDto(SalesOrder entity, SalesOrderDto dto)
        {
            dto.Id = entity.Id;
            dto.OrderNumber = entity.OrderNumber;
            dto.Total = entity.Total;
            dto.IssuedDate = entity.IssuedDate;
            dto.Items = entity.Items.Select(EntityToOrderItemDto).ToList();
            dto.CustomerId = entity.CustomerId;
            return dto;
        }

        public SalesOrderItem DtoToOrderItem(SalesOrderItemDto dto)
        {
            return new()
            {
                Id = dto.Id,
                ProductId = dto.ProductId,
                IsBook = dto.IsBook,
                OrderId = dto.OrderId,
                Quantity = dto.Quantity
            };
        }

        public SalesOrderItemDto EntityToOrderItemDto(SalesOrderItem dto)
        {
            return new()
            {
                Id = dto.Id,
                ProductId = dto.ProductId,
                IsBook = dto.IsBook,
                OrderId = dto.OrderId,
                Quantity = dto.Quantity
            };
        }

        public void MapToExistingEntity(SalesOrderDto dto, SalesOrder entity)
        {
            throw new NotImplementedException();
        }
    }

}