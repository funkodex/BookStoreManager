using DataAccess.Models.Entities;
using DataAccess.Models.Entities.BookStore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public interface IRepository<TEntity,  TId> where TEntity : class, IEntity<TId> where TId : struct
{
    Task<TEntity> CreateAsync(TEntity entity);
    Task<List<TEntity>> FindAllAsync();
    Task<List<TEntity>> FindAllIncludingAsync(string[] relations);
    Task<TEntity?> FindByIdAsync(TId id);
    Task<TEntity?> FindByIdIncludingAsync(TId id,params string[] relations);
    ValueTask<bool> ExistsByIdAsync(TId id);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
    Task<int> DeleteManyAsync(List<TId> ids);
    DbSet<TEntity> Entities { get; }
}


public interface IOrderRepository : IRepository<SalesOrder, long>
{
}

public interface IPurchaseRepository : IRepository<PurchaseOrder, long>
{
}

public interface IBundleRepository : IRepository<Bundle, long>
{
}

public interface IPaymentRepository : IRepository<Payment, long>
{
}

public interface ICategoryRepository : IRepository<Category, long>
{
}

public interface IProductRepository : IRepository<GenericProduct, long>
{
}

public interface IBookRepository : IRepository<Book, long>
{
}

public interface IAuthorRepository : IRepository<Author, long>
{
}

public interface IPublisherRepository : IRepository<Publisher, long>
{
}

public interface ICustomerRepository : IRepository<Customer, long>
{
}

public interface ISupplierRepository : IRepository<Supplier, long>
{
}

public interface IEmployeeRepository : IRepository<Employee, long>
{
}

public interface IEmployeeShiftRepository : IRepository<EmployeeShift, long>
{
}