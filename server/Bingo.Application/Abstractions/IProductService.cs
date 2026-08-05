using Bingo.Application.Dtos.Product;
using Bingo.Application.Types;

namespace Bingo.Application.Abstractions;

public interface IProductService
{
    Task<ServiceResult<long>> CreateAsync(ProductCreateDto dto, CancellationToken cancellationToken);
    Task<ServiceResult<ProductViewDto[]>> GetAllAsync(CancellationToken cancellationToken);
    Task<ServiceResult<ProductViewDto>> GetByIdAsync(long id, CancellationToken cancellationToken);
    Task<ServiceResult<ProductViewDto>> GetBySlugAsync(string slug, CancellationToken cancellationToken);
    Task<ServiceResult<bool>> AddTagAsync(long productId, long tagId, CancellationToken cancellationToken);
    Task<ServiceResult<bool>> RemoveTagAsync(long productId, long tagId, CancellationToken cancellationToken);
}