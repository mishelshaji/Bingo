using Bingo.Application.Dtos.ContactRequest;
using Bingo.Application.Types;

namespace Bingo.Application.Abstractions;

public interface IContactRequestService
{
    Task<ServiceResult<ContactRequestViewDto[]>> GetAllAsync(CancellationToken cancellationToken);
    Task<ServiceResult<ContactRequestViewDto?>> GetByIdAsync(long id, CancellationToken cancellationToken);
    Task<ServiceResult<ContactRequestViewDto?>> CreateAsync(ContactRequestCreateDto dto, CancellationToken cancellationToken);
    Task<ServiceResult<bool>> UpdateAsync(long id, ContactRequestCreateDto dto, CancellationToken cancellationToken);
    Task<ServiceResult<bool>> DeleteAsync(long id, CancellationToken cancellationToken);
}