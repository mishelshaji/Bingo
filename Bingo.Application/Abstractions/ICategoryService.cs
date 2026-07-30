using Bingo.Application.Dtos.Category;
using Bingo.Application.Types;

namespace Bingo.Application.Abstractions;

public interface ICategoryService
{
    Task<ServiceResult<IEnumerable<CategoryViewDto>>> GetAllAsync(CancellationToken cancellationToken);
    Task<ServiceResult<CategoryViewDto?>> GetByIdAsync(long id, CancellationToken cancellationToken);
    Task<ServiceResult<CategoryViewDto?>> CreateAsync(CategoryCreateDto dto, CancellationToken cancellationToken);
    Task<ServiceResult<CategoryViewDto?>> UpdateAsync(long id, CategoryCreateDto dto, CancellationToken cancellationToken);
    Task<ServiceResult<bool>> DeleteAsync(long id, CancellationToken cancellationToken);
}