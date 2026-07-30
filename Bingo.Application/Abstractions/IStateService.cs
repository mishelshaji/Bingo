using Bingo.Application.Dtos.State;
using Bingo.Application.Types;

namespace Bingo.Application.Abstractions;

public interface IStateService
{
    Task<ServiceResult<IEnumerable<StateViewDto>>> GetAllAsync(CancellationToken cancellationToken);
    Task<ServiceResult<StateViewDto?>> GetByIdAsync(long id, CancellationToken cancellationToken);
    Task<ServiceResult<StateViewDto?>> CreateAsync(StateCreateDto dto, CancellationToken cancellationToken);
    Task<ServiceResult<StateViewDto?>> UpdateAsync(long id, StateCreateDto dto, CancellationToken cancellationToken);
    Task<ServiceResult<bool>> DeleteAsync(long id, CancellationToken cancellationToken);
}