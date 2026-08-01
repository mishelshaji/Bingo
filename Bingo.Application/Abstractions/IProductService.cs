using Bingo.Application.Dtos.Product;
using Bingo.Application.Types;

namespace Bingo.Application.Abstractions;

public interface IProductService
{
    Task<ServiceResult<long>> CreateAsync(ProductCreateDto dto, CancellationToken cancellationToken);
    Task<ServiceResult<ProductViewDto[]>> GetAllAsync(CancellationToken cancellationToken);
}