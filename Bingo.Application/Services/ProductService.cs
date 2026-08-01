using Bingo.Application.Abstractions;
using Bingo.Application.Dtos.Category;
using Bingo.Application.Dtos.Product;
using Bingo.Application.Dtos.Tag;
using Bingo.Application.Types;
using Bingo.Core.Domains;
using Bingo.Infrastructure.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Bingo.Application.Services;

public class ProductService(ApplicationDbContext db, IValidator<ProductCreateDto> validator): IProductService
{
    private readonly IQueryable<Product> _baseQuery = db.Products
        .Where(p=>p.DeletedAt == null);
    
    public async Task<ServiceResult<ProductViewDto[]>> GetAllAsync(CancellationToken cancellationToken)
    {
        var products = await _baseQuery
            .Include(p => p.Category)
            .Include(p => p.Brand)
            .Include(p => p.ProductTags)
            .ThenInclude(t => t.Tag)
            .Select(p => new ProductViewDto()
            {
                Id = p.Id,
                Name = p.Name,
                ShortDescription = p.ShortDescription,
                DetailedDescription = p.DetailedDescription,
                Status = p.Status,
                Height = p.Height,
                Width = p.Width,
                Weight = p.Weight,
                Slug = p.Slug,
                Stock = p.Stock,
                SalesPrice = p.SalesPrice,
                RegularPrice = p.RegularPrice,
                Category = p.Category == null? null : new CategoryViewDto()
                {
                    Id = p.Category.Id,
                    Name = p.Category.Name,
                    Slug = p.Category.Slug,
                    Description = p.Category.Description,
                },
                Tags = p.ProductTags == null ? null : p.ProductTags.Select(pt=>new TagViewDto()
                {
                    Id = pt.Tag.Id,
                    Name = pt.Tag.Name,
                    Description = pt.Tag.Description,
                })
            })
            .ToArrayAsync(cancellationToken);
        
        return ServiceResult<ProductViewDto[]>.SuccessResult(products);
    }
    
    public async Task<ServiceResult<long>> CreateAsync(ProductCreateDto dto, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(dto, cancellationToken);
        if (!validationResult.IsValid)
        {
            return ServiceResult<long>.ValidationErrorResult(validationResult.Errors.Select(e=>e.ErrorMessage));
        }

        if (dto.CategoryId != null)
        {
            var categoryExists = await db.Categories
                .AnyAsync(c=>c.Id == dto.CategoryId && c.DeletedAt == null, cancellationToken);
            if (!categoryExists)
                return ServiceResult<long>.ValidationErrorResult(["Invalid category id."]);
        }

        if (dto.BrandId != null)
        {
            var brandExists = await db.Brands
                .AnyAsync(b=>b.Id == dto.BrandId && b.DeletedAt == null, cancellationToken);
            if (!brandExists)
                return ServiceResult<long>.ValidationErrorResult(["Invalid brand."]);
        }
        
        var tagIds = dto.TagIds?.Distinct();
        if (tagIds!=null)
        {
            var tagIdsFromDB = await db.Tags
                .CountAsync(t => tagIds.Contains(t.Id) && t.DeletedAt == null, cancellationToken);

            if (tagIds.Count() != tagIdsFromDB)
                return ServiceResult<long>.ValidationErrorResult(["Invalid tag ids."]);
        }

        var product = new Product
        {
            Name = dto.Name,
            NormalizedName = dto.Name.ToUpper(),
            BrandId = dto.BrandId,
            CategoryId = dto.CategoryId,
            Status = dto.Status,
            Stock = dto.Stock,
            SalesPrice = dto.SalesPrice,
            RegularPrice = dto.RegularPrice,
            Height = dto.Height,
            Width = dto.Width,
            Weight = dto.Weight,
            Slug = dto.Slug,
            ShortDescription = dto.ShortDescription,
            DetailedDescription = dto.DetailedDescription,
            ProductTags = dto.TagIds.Select(x => new ProductTag { TagId = x }).ToList(),
        };
        await db.AddAsync(product, cancellationToken);
        await db.SaveChangesAsync(cancellationToken);
        return ServiceResult<long>.SuccessResult(product.Id);
    }
}