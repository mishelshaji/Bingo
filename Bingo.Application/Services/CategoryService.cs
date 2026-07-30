using Bingo.Application.Abstractions;
using Bingo.Application.Dtos.Category;
using Bingo.Application.Types;
using Bingo.Core.Domains;
using Bingo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Bingo.Application.Services;

public class CategoryService(ApplicationDbContext db): ICategoryService
{
    private readonly IQueryable<Category> _baseQuery = db.Categories
        .Where(c => c.DeletedAt == null);
    
    public async Task<ServiceResult<IEnumerable<CategoryViewDto>>> GetAllAsync(CancellationToken cancellationToken)
    {
        var categoriesFromDb = await _baseQuery
            .Select(c => new CategoryViewDto()
            {
                Id = c.Id,
                Name = c.Name,
                Slug = c.Slug,
                Description = c.Description,
            }).ToArrayAsync(cancellationToken);

        return ServiceResult<IEnumerable<CategoryViewDto>>.SuccessResult(categoriesFromDb);
    }
    
    public async Task<ServiceResult<CategoryViewDto?>> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        var categoriesFromDb = await _baseQuery
            .Where(c => c.Id == id)
            .Select(c => new CategoryViewDto()
            {
                Id = c.Id,
                Name = c.Name,
                Slug = c.Slug,
                Description = c.Description,
            }).FirstOrDefaultAsync(cancellationToken);

        if (categoriesFromDb == null)
        {
            return ServiceResult<CategoryViewDto?>.NotFoundResult();
        }

        return ServiceResult<CategoryViewDto?>.SuccessResult(categoriesFromDb);
    }

    public async Task<ServiceResult<CategoryViewDto?>> CreateAsync(CategoryCreateDto dto, CancellationToken cancellationToken)
    {
        // STEP 1: Validate Name and Slug.
        if (string.IsNullOrWhiteSpace(dto.Name))
            return ServiceResult<CategoryViewDto?>.ValidationErrorResult(["Invalid name"]);
        
        if (string.IsNullOrWhiteSpace(dto.Slug))
            return ServiceResult<CategoryViewDto?>.ValidationErrorResult(["Invalid slug"]);

        // STEP 2: Ensure the uniqueness of the category name and slug.
        var categoryExists = await _baseQuery
            .AnyAsync(c => c.Name == dto.Name || c.Slug == dto.Slug, cancellationToken);
        
        if(categoryExists)
            return ServiceResult<CategoryViewDto?>.ValidationErrorResult(["Category already exists."]);

        // STEP 3: Create a category and return the result.
        var category = new Category
        {
            Name = dto.Name,
            Slug = dto.Slug,
            Description = dto.Description,
        };

        await db.Categories.AddAsync(category, cancellationToken);
        await db.SaveChangesAsync(cancellationToken);
        
        return ServiceResult<CategoryViewDto?>.CreatedResult(new()
        {
            Id = category.Id,
            Name = category.Name,
            Slug = category.Slug,
            Description = category.Description,
        });
    }
    
    public async Task<ServiceResult<CategoryViewDto?>> UpdateAsync(long id, CategoryCreateDto dto, CancellationToken cancellationToken)
    {
        // STEP 1: Validate Name and Slug.
        if (string.IsNullOrWhiteSpace(dto.Name))
            return ServiceResult<CategoryViewDto?>.ValidationErrorResult(["Invalid name"]);
        
        if (string.IsNullOrWhiteSpace(dto.Slug))
            return ServiceResult<CategoryViewDto?>.ValidationErrorResult(["Invalid slug"]);
        
        // STEP 2: Check if the category exists.
        var category = await _baseQuery.FirstOrDefaultAsync(c =>c.Id == id, cancellationToken);
        if(category == null)
            return ServiceResult<CategoryViewDto?>.NotFoundResult();
        
        // STEP 3: Ensure the uniqueness of the category name and slug.
        var categoryExists = await _baseQuery
            .AnyAsync(c => (c.Name == dto.Name || c.Slug == dto.Slug) && c.Id != id, cancellationToken);
        
        if(categoryExists)
            return ServiceResult<CategoryViewDto?>.ValidationErrorResult(["Category already exists."]);

        // STEP 4: Update category and return the result.
        category.Name = dto.Name;
        category.Slug = dto.Slug;
        category.Description = dto.Description;

        await db.SaveChangesAsync(cancellationToken);
        
        return ServiceResult<CategoryViewDto?>.UpdatedResult(new()
        {
            Id = category.Id,
            Name = category.Name,
            Slug = category.Slug,
            Description = category.Description,
        });
    }

    public async Task<ServiceResult<bool>> DeleteAsync(long id, CancellationToken cancellationToken)
    {
        var category = await _baseQuery.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        if (category == null)
            return ServiceResult<bool>.NotFoundResult();
        
        category.DeletedAt = DateTime.UtcNow;
        await db.SaveChangesAsync(cancellationToken);
        return ServiceResult<bool>.DeletedResult(true);
    }
}