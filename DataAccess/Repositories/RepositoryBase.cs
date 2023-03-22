using Core;
using DataAccess.Models.Entities;
using DataAccess.Models.Entities.BookStore;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Repositories;



public abstract class RepositoryBase<TEntity, TId, TContext> : IRepository<TEntity, TId> where TEntity : class, IEntity<TId> where TId : struct where TContext : DbContext, IEntityManager<TEntity, TId>
{
    protected readonly TContext _context;
    private readonly DbSet<TEntity> entities;

    public DbSet<TEntity> Entities => entities;

    protected RepositoryBase(TContext context)
    {
        _context = context;
        entities = context.GetDbSet();
    }




    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        Entities.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<List<TEntity>> FindAllAsync()
    {
        return await Entities.ToListAsync();
    }

    public async Task<List<TEntity>> FindAllIncludingAsync(string[] relations)
    {
        if (relations.Length == 0)
        {
            return await FindAllAsync();
        }

        IQueryable<TEntity> queryable = entities;
        foreach (var relation in relations)
        {
            queryable = queryable.Include(relation);
        }

        return await queryable.ToListAsync();
    }

    public async ValueTask<bool> ExistsByIdAsync(TId id)
    {
        return await Entities.AnyAsync(it => id.Equals(it.Id)); ;
    }

    public async Task<TEntity?> FindByIdAsync(TId id)
    {
        return await _context.FindAsync<TEntity>(id); ;
    }
    public async Task<TEntity?> FindByIdIncludingAsync(TId id, params string[] relations)
    {
        IQueryable<TEntity> queryable = entities;
        foreach (var relation in relations)
        {
            queryable = queryable.Include(relation);
        }
        return await queryable.FirstOrDefaultAsync(e=>id.Equals(e.Id)); ;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(TEntity entity)
    {
        Entities.Remove(entity);
        await _context.SaveChangesAsync();
    }
    public  Task<int> DeleteManyAsync(List<TId> ids)
    {
        return Entities.Where(e=> ids.Contains((TId)e.Id!)).BatchDeleteAsync();
        //await _context.SaveChangesAsync();
    }


}



public class OrderRepository<TContext> : RepositoryBase<SalesOrder, long, TContext>, IOrderRepository where TContext : DbContext, IEntityManager<SalesOrder, long>
{
    public OrderRepository(TContext context) : base(context)
    {

    }
}


public class PurchaseRepository<TContext> : RepositoryBase<PurchaseOrder, long, TContext>, IPurchaseRepository where TContext : DbContext, IEntityManager<PurchaseOrder, long>
{
    public PurchaseRepository(TContext context) : base(context)
    {

    }
}

public class BundleRepository<TContext> : RepositoryBase<Bundle, long, TContext>, IBundleRepository where TContext : DbContext, IEntityManager<Bundle, long>
{
    public BundleRepository(TContext context) : base(context)
    {

    }
}

public class PaymentRepository<TContext> : RepositoryBase<Payment, long, TContext>, IPaymentRepository where TContext : DbContext, IEntityManager<Payment, long>
{
    public PaymentRepository(TContext context) : base(context)
    {

    }
}

public class CategoryRepository<TContext> : RepositoryBase<Category, long, TContext>, ICategoryRepository where TContext : DbContext, IEntityManager<Category, long>
{
    public CategoryRepository(TContext context) : base(context)
    {
    }
}

public class ProductRepository<TContext> : RepositoryBase<GenericProduct, long, TContext>, IProductRepository where TContext : DbContext, IEntityManager<GenericProduct, long>
{
    public ProductRepository(TContext context) : base(context)
    {
    }
}

public class BookRepository : RepositoryBase<Book, long, BookStoreInventoryContext>, IBookRepository
{
    public BookRepository(BookStoreInventoryContext context) : base(context)
    {
    }
}

public class AuthorRepository : RepositoryBase<Author, long, BookStoreInventoryContext>, IAuthorRepository
{
    public AuthorRepository(BookStoreInventoryContext context) : base(context)
    {
    }
}

public class PublisherRepository : RepositoryBase<Publisher, long, BookStoreInventoryContext>, IPublisherRepository
{
    public PublisherRepository(BookStoreInventoryContext context) : base(context)
    {
    }
}

public class CustomerRepository<TContext> : RepositoryBase<Customer, long, TContext>, ICustomerRepository where TContext : DbContext, IEntityManager<Customer, long>
{
    public CustomerRepository(TContext context) : base(context)
    {
    }
}

public class SupplierRepository<TContext> : RepositoryBase<Supplier, long, TContext>, ISupplierRepository where TContext : DbContext, IEntityManager<Supplier, long>
{
    public SupplierRepository(TContext context) : base(context)
    {
    }
}