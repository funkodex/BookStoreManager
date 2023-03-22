using Audit.EntityFramework;
using DataAccess.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public interface IEntityManager<TEntity, TId> where TEntity : class, IEntity<TId> where TId : struct
    {
        public DbSet<TEntity> GetDbSet();
    }

    [AuditDbContext(Mode = AuditOptionMode.OptIn)]
    public class InventoryContext : AuditIdentityDbContext<AppUser>, IEntityManager<SalesOrder, long>, IEntityManager<PurchaseOrder, long>, IEntityManager<Bundle, long>, IEntityManager<Payment, long>, IEntityManager<Product, long>, IEntityManager<Category, long>, IEntityManager<Customer, long>, IEntityManager<Supplier, long>, IEntityManager<Employee, long>, IEntityManager<EmployeeShift, long>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SalesOrder> Orders { get; set; }
        public DbSet<PurchaseOrder> Purchases { get; set; }
        public DbSet<Bundle> Bundles { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeShift> EmployeeShifts { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }


        public InventoryContext()
        {

        }
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server = localhost; port = 3306; database = inventoryDb; user= root; password = ;";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>().Property<bool>("is_deleted");
            modelBuilder.Entity<Category>().Property<bool>("is_deleted");
            modelBuilder.Entity<SalesOrder>().Property<bool>("is_deleted");
            modelBuilder.Entity<SalesOrderItem>().Property<bool>("is_deleted");

            modelBuilder.Entity<ProductSupplier>()
              .HasOne(x => x.Product)
              .WithMany(p => p.ProductSuppliers)
              .HasForeignKey(x => x.ProductId);

            modelBuilder.Entity<ProductSupplier>()
                .HasOne(x => x.Supplier)
                .WithMany(s => s.SupplierProducts)
                .HasForeignKey(x => x.SupplierId);


            if (this.GetType() == typeof(InventoryContext))
            {
                modelBuilder.Entity<Category>().Ignore(x => x.IsBookCategory);
                modelBuilder.Entity<SalesOrderItem>().Ignore(x => x.IsBook);
            }

            modelBuilder.Entity<Product>().HasQueryFilter(x => EF.Property<bool>(x, "is_deleted") == false);
            modelBuilder.Entity<Category>().HasQueryFilter(x => EF.Property<bool>(x, "is_deleted") == false);
            modelBuilder.Entity<SalesOrder>().HasQueryFilter(x => EF.Property<bool>(x, "is_deleted") == false);

            modelBuilder.Entity<Product>().HasMany<BundleItem>().WithOne(b => b.Product).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Product>().HasMany<OrderItem>().WithOne(b => b.Product).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Product>().HasOne(p => p.Category).WithMany(c => c.Products).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Employee>().HasOne(e=>e.Account).WithOne().HasForeignKey<Employee>(e=>e.AccountId);
            base.OnModelCreating(modelBuilder);

        }

        DbSet<SalesOrder> IEntityManager<SalesOrder, long>.GetDbSet()
        {
            return Orders;

        }

        DbSet<PurchaseOrder> IEntityManager<PurchaseOrder, long>.GetDbSet()
        {
            return Purchases;

        }

        DbSet<Product> IEntityManager<Product, long>.GetDbSet()
        {
            return Products;

        }

        DbSet<Category> IEntityManager<Category, long>.GetDbSet()
        {
            return Categories;

        }

        DbSet<Customer> IEntityManager<Customer, long>.GetDbSet()
        {
            return Customers;

        }

        DbSet<Supplier> IEntityManager<Supplier, long>.GetDbSet()
        {
            return Suppliers;

        }

        public DbSet<Payment> GetDbSet()
        {
            return Payments;
        }


        protected void UpdateSoftDeletedStatuses()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Metadata.FindProperty("is_deleted") != null)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.CurrentValues["is_deleted"] = false;

                            break;
                        case EntityState.Deleted:
                            entry.State = EntityState.Modified;
                            entry.CurrentValues["is_deleted"] = true;
                            break;

                    }
                }

            }
        }

        DbSet<Bundle> IEntityManager<Bundle, long>.GetDbSet()
        {
            return Bundles;
        }

        DbSet<Employee> IEntityManager<Employee, long>.GetDbSet()
        {
            return Employees;
        }

        DbSet<EmployeeShift> IEntityManager<EmployeeShift, long>.GetDbSet()
        {
            return EmployeeShifts;
        }
    }
}
