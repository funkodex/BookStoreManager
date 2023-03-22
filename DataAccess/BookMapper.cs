//using DataAccess.Models.Dtos;

using DataAccess.Models.Entities;
using DataAccess.Models.Entities.BookStore;

namespace DataAccess.Mappers
{
    public class BookMapper : IBookMapper
    {
        public Book MapToEntity(BookDto dto)
        {
            return new()
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Quantity = dto.Quantity,
                CostPrice = dto.CostPrice,
                Markup = dto.Markup,
                RetailPrice = dto.RetailPrice,
                WholeSalePrice = dto.WholeSalePrice,
                CategoryId = dto.CategoryId,
                ImageUrl = dto.ImageUrl,
                Tags = dto.Tags,
                Edition = dto.Edition,
                Year = dto.Year,
                PublisherId = dto.PublisherId,
                BookAuthors = getAuthors(dto),
                ProductSuppliers = getSuppliers(dto),
                Barcode = dto.Barcode,
                QrCode = dto.QrCode
            };
        }

        private static List<ProductSupplier> getSuppliers(BookDto dto)
        {
            return dto.SupplierIds.Select(authorId => new ProductSupplier() { ProductId = dto.Id, SupplierId = authorId }).ToList();
        }

        private static List<BookAuthor> getAuthors(BookDto dto)
        {
            return dto.AuthorIds.Select(authorId => new BookAuthor() { BookId = dto.Id, AuthorId = authorId }).ToList();
        }

        public BookDto MapToDto(Book entity)
        {
            return new()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Quantity = entity.Quantity,
                CostPrice = entity.CostPrice,
                Markup = entity.Markup,
                RetailPrice = entity.RetailPrice,
                WholeSalePrice = entity.WholeSalePrice,
                CategoryId = entity.CategoryId,
                ImageUrl = entity.ImageUrl,
                Tags = entity.Tags,
                Edition = entity.Edition,
                Year = entity.Year,
                PublisherId = entity.PublisherId,
                AuthorIds = getAuthorIds(entity),
                SupplierIds = getSupplierIds(entity),
                Barcode = entity.Barcode,
                QrCode = entity.QrCode
            };
        }

        private static List<long> getSupplierIds(Book entity)
        {
            return entity.ProductSuppliers.Where(x=>x.SupplierId is not null).Select(a => a.SupplierId.Value).ToList();
        }

        private static List<long> getAuthorIds(Book entity)
        {
            return entity.BookAuthors.Where(x => x.AuthorId is not null).Select(a => a.AuthorId.Value).ToList();
        }

        public BookDto MapToExistingDto(Book entity, BookDto dto)
        {
            dto.Id = entity.Id;
            dto.Name = entity.Name;
            dto.Description = entity.Description;
            dto.Quantity = entity.Quantity;
            dto.CostPrice = entity.CostPrice;
            dto.Markup = entity.Markup;
            dto.RetailPrice = entity.RetailPrice;
            dto.WholeSalePrice = entity.WholeSalePrice;
            dto.CategoryId = entity.CategoryId;
            dto.ImageUrl = entity.ImageUrl;
            dto.Tags = entity.Tags;
            dto.Edition = entity.Edition;
            dto.Year = entity.Year;
            dto.PublisherId = entity.PublisherId;
            dto.AuthorIds = getAuthorIds(entity);
            dto.SupplierIds = getSupplierIds(entity);
            dto.Barcode = entity.Barcode;
            dto.QrCode = entity.QrCode;
            return dto;
        }

        public void MapToExistingEntity(BookDto dto, Book entity)
        {
            entity.Id = dto.Id;
            entity.Name = dto.Name;
            entity.Description = dto.Description;
            entity.Quantity = dto.Quantity;
            entity.CostPrice = dto.CostPrice;
            entity.Markup = dto.Markup;
            entity.RetailPrice = dto.RetailPrice;
            entity.WholeSalePrice = dto.WholeSalePrice;
            entity.CategoryId = dto.CategoryId;
            entity.ImageUrl = dto.ImageUrl;
            entity.Tags = dto.Tags;
            entity.Edition = dto.Edition;
            entity.Year = dto.Year;
            entity.PublisherId = dto.PublisherId;
            entity.BookAuthors = getAuthors(dto);
            entity.ProductSuppliers = getSuppliers(dto);
            entity.Barcode = dto.Barcode;
            entity.QrCode = dto.QrCode;
        }
    }

}