//using DataAccess.Models.Dtos;

using DataAccess.Models.Entities;

namespace DataAccess.Mappers
{
    public class CustomerMapper : ICustomerMapper
    {
        public Customer MapToEntity(CustomerDto dto)
        {
            return new()
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Address = dto.Address,
                PhoneNumber = dto.PhoneNumber,
                Orders = dto.OrderIds.Select(id => new SalesOrder() { Id = id }).ToList()
            };
        }

        public CustomerDto MapToDto(Customer entity)
        {
            return new()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Address = entity.Address,
                PhoneNumber = entity.PhoneNumber,
                OrderIds = entity.Orders.Select(o => o.Id.Value).ToList()
            };
        }

        public CustomerDto MapToExistingDto(Customer entity, CustomerDto dto)
        {
            dto.Id = entity.Id;
            dto.FirstName = entity.FirstName;
            dto.LastName = entity.LastName;
            dto.Address = entity.Address;
            dto.PhoneNumber = entity.PhoneNumber;
            dto.OrderIds = entity.Orders.Select(o => o.Id.Value).ToList();
            return dto;
        }

        public void MapToExistingEntity(CustomerDto dto, Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}