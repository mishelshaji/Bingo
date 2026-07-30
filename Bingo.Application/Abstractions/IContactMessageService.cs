using Bingo.Application.Dtos.ContactMessage;
using Bingo.Application.Types;

namespace Bingo.Application.Abstractions;

public interface IContactMessageService
{
    Task<ServiceResult<ContactMessageViewDto[]>> GetAllAsync(CancellationToken cancellationToken);
    Task<ServiceResult<ContactMessageViewDto?>> GetByIdAsync(long id, CancellationToken cancellationToken);
    Task<ServiceResult<ContactMessageViewDto?>> CreateAsync(ContactMessageCreateDto dto, CancellationToken cancellationToken);
    Task<ServiceResult<bool>> UpdateAsync(long id, ContactMessageCreateDto dto, CancellationToken cancellationToken);
    Task<ServiceResult<bool>> DeleteAsync(long id, CancellationToken cancellationToken);
}