//using DataAccess.Models.Dtos;

using DataAccess.Models.Entities;

namespace DataAccess.Mappers
{
    public class PurchaseOrderMapper : IPurchaseOrderMapper
    {
        public PurchaseOrder MapToEntity(PurchaseOrderDto dto)
        {
            return new()
            {
                Id = dto.Id,
                Total = dto.Total,
                IssuedDate = dto.IssuedDate,
                Items = dto.Items.Select(DtoToPurchaseOrderItem).ToList(),
                SupplierId = dto.SupplierId
            };
        }

        public PurchaseOrderDto MapToDto(PurchaseOrder entity)
        {
            return new()
            {
                Id = entity.Id,
                Total = entity.Total,
                IssuedDate = entity.IssuedDate,
                Items = entity.Items.Select(EntityToPurchaseOrderItemDto).ToList(),
                SupplierId = entity.SupplierId
            };
        }

        public PurchaseOrderDto MapToExistingDto(PurchaseOrder entity, PurchaseOrderDto dto)
        {
            dto.Id = entity.Id;
            dto.Total = entity.Total;
            dto.IssuedDate = entity.IssuedDate;
            dto.Items = entity.Items.Select(EntityToPurchaseOrderItemDto).ToList();
            dto.SupplierId = entity.SupplierId;
            return dto;
        }

        public SalesOrderItem DtoToSalesOrderItem(SalesOrderItemDto dto)
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

        public SalesOrderItemDto EntityToSalesOrderItemDto(SalesOrderItem dto)
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

        public PurchaseOrderItem DtoToPurchaseOrderItem(PurchaseOrderItemDto dto)
        {
            return new()
            {
                Id = dto.Id,
                ProductId = dto.ProductId,
                IsBook = dto.IsBook,
                PurchaseId = dto.PurchaseId,
                Quantity = dto.Quantity
            };
        }

        public PurchaseOrderItemDto EntityToPurchaseOrderItemDto(PurchaseOrderItem dto)
        {
            return new()
            {
                Id = dto.Id,
                ProductId = dto.ProductId,
                IsBook = dto.IsBook,
                PurchaseId = dto.PurchaseId,
                Quantity = dto.Quantity
            };
        }

        public void MapToExistingEntity(PurchaseOrderDto dto, PurchaseOrder entity)
        {
            throw new NotImplementedException();
        }
    }

}