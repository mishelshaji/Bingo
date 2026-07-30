using Bingo.Application.Dtos.Country;
using Bingo.Application.Types;

namespace Bingo.Application.Abstractions;

public interface ICountryService
{
    Task<ServiceResult<IEnumerable<CountryViewDto>>> GetAllAsync(CancellationToken cancellationToken);
    Task<ServiceResult<CountryViewDto?>> GetByIdAsync(long id, CancellationToken cancellationToken);
    Task<ServiceResult<CountryViewDto?>> CreateAsync(CountryCreateDto dto, CancellationToken cancellationToken);
    Task<ServiceResult<CountryViewDto?>> UpdateAsync(long id, CountryCreateDto dto, CancellationToken cancellationToken);
    Task<ServiceResult<bool>> DeleteAsync(long id, CancellationToken cancellationToken);
}