//using DataAccess.Models.Dtos;

using DataAccess.Models.Entities;

namespace DataAccess.Mappers
{
    public class SupplierMapper : ISupplierMapper
    {
        public Supplier MapToEntity(SupplierDto dto)
        {
            return new()
            {
                Id = dto.Id,
                Name = dto.Name,
                DebtOwed = dto.DebtOwed,
                DebtPayed = dto.DebtPayed,
                Address = dto.Address
            };
        }

        public SupplierDto MapToDto(Supplier entity)
        {
            return new()
            {
                Id = entity.Id,
                Name = entity.Name,
                DebtOwed = entity.DebtOwed,
                DebtPayed = entity.DebtPayed,
                Address = entity.Address
            };
        }

        public SupplierDto MapToExistingDto(Supplier entity, SupplierDto dto)
        {
            dto.Id = entity.Id;
            dto.Name = entity.Name;
            dto.DebtOwed = entity.DebtOwed;
            dto.DebtPayed = entity.DebtPayed;
            dto.Address = entity.Address;
            return dto;
        }

        public void MapToExistingEntity(SupplierDto dto, Supplier entity)
        {
            entity.Id = dto.Id;
            entity.Name = dto.Name;
            entity.DebtOwed = dto.DebtOwed;
            entity.DebtPayed = dto.DebtPayed;
            entity.Address = dto.Address;
        }
    }
}