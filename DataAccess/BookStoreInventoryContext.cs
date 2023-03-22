using DataAccess;
using DataAccess.Models.Entities;
using DataAccess.Models.Entities.BookStore;
using Microsoft.EntityFrameworkCore;

namespace Core
{


    public class BookStoreInventoryContext : InventoryContext, IEntityManager<Book, long>, IEntityManager<Author, long>, IEntityManager<Publisher, long>, IEntityManager<GenericProduct, long>
    {

        public new DbSet<GenericProduct> Products { get; set; }
        public DbSet<Book> Books { get; init; }

        public DbSet<Author> Authors { get; init; }

        public DbSet<Publisher> Publishers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server = localhost; port = 3306; database = bookStoreDb; user= root; password = ;";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                          .UseSnakeCaseNamingConvention();


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<ProductSupplier>().HasKey(nameof(ProductSupplier.ProductId), nameof(ProductSupplier.SupplierId));

            modelBuilder.Entity<BookAuthor>().HasKey(nameof(BookAuthor.BookId), nameof(BookAuthor.AuthorId));

          
            modelBuilder.Entity<BookAuthor>()
                .HasOne(x => x.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(x => x.BookId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(x => x.Author)
                .WithMany(a => a.AuthorBooks)
                .HasForeignKey(x => x.AuthorId);

            modelBuilder.Entity<Product>()
                .HasQueryFilter(x => EF.Property<bool>(x, "is_deleted") == false);

            modelBuilder.Entity<Category>().HasQueryFilter(x => EF.Property<bool>(x, "is_deleted") == false);
            modelBuilder.Entity<SalesOrder>().HasQueryFilter(x => EF.Property<bool>(x, "is_deleted") == false);

            modelBuilder.Entity<Product>()
                .HasDiscriminator<string>("product_type")
                .HasValue<GenericProduct>("generic")
                .HasValue<Book>("book");

            

            base.OnModelCreating(modelBuilder);


        }

        public override int SaveChanges()
        {
            UpdateSoftDeletedStatuses();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            UpdateSoftDeletedStatuses();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }




        DbSet<Book> IEntityManager<Book, long>.GetDbSet() => Books;


        DbSet<Author> IEntityManager<Author, long>.GetDbSet() => Authors;

        DbSet<GenericProduct> IEntityManager<GenericProduct, long>.GetDbSet() => Products;

        DbSet<Publisher> IEntityManager<Publisher, long>.GetDbSet() => Publishers;
    }


}
