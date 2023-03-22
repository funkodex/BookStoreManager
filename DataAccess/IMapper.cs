//using DataAccess.Models.Dtos;

using DataAccess.Models.Dtos;
using DataAccess.Models.Entities;
using DataAccess.Models.Entities.BookStore;
using Mapster;

namespace DataAccess
{


    public interface IMapper<T, TDto>
    {
        public TDto MapToDto(T entity);
        public TDto MapToExistingDto(T entity, TDto dto);
        public T MapToEntity(TDto dto);
        public void MapToExistingEntity(TDto dto, T entity);

    }




    public interface ICategoryMapper : IMapper<Category, CategoryDto>
    {
    }


    public interface IProductMapper : IMapper<GenericProduct, ProductDto>
    {
    }


    public interface IBookMapper : IMapper<Book, BookDto>
    {
    }


    public interface IAuthorMapper : IMapper<Author, AuthorDto>
    {
    }

    public interface IPublisherMapper : IMapper<Publisher, PublisherDto>
    {
    }


    public interface ISalesOrderMapper : IMapper<SalesOrder, SalesOrderDto>
    {
    }

    public interface IPurchaseOrderMapper : IMapper<PurchaseOrder, PurchaseOrderDto>
    {
    }

    public interface IBundleMapper : IMapper<Bundle, BundleDto>
    {
    }

    public interface ISupplierMapper : IMapper<Supplier, SupplierDto>
    {
    }

    public interface IPaymentMapper : IMapper<Payment, PaymentDto>
    {

    }


    public interface ICustomerMapper : IMapper<Customer, CustomerDto>
    {
    }

    public interface IEmployeeMapper : IMapper<Employee, EmployeeDto>
    {
    }



}

namespace DataAccess.Mappers
{
    public class PaymentMapper : IPaymentMapper
    {
        public Payment MapToEntity(PaymentDto dto)
        {
            return new()
            {
                Id = dto.Id,
                IssuedDate = dto.IssuedDate,
                DueAmount = dto.DueAmount,
                TenderedAmount = dto.TenderedAmount,
                DiscountAmount = dto.DiscountAmount,
                OrderId = dto.OrderId,
            };
        }

        public PaymentDto MapToDto(Payment entity)
        {
            return new()
            {
                Id = entity.Id,
                IssuedDate = entity.IssuedDate,
                DueAmount = entity.DueAmount,
                TenderedAmount = entity.TenderedAmount,
                DiscountAmount = entity.DiscountAmount,
                OrderId = entity.OrderId,
            };
        }

        public PaymentDto MapToExistingDto(Payment entity, PaymentDto dto)
        {
            dto.Id = entity.Id;
            dto.IssuedDate = entity.IssuedDate;
            dto.DueAmount = entity.DueAmount;
            dto.TenderedAmount = entity.TenderedAmount;
            dto.DiscountAmount = entity.DiscountAmount;
            dto.OrderId = entity.OrderId;
            return dto;
        }

        public void MapToExistingEntity(PaymentDto dto, Payment entity)
        {
            throw new NotImplementedException();
        }
    }
}