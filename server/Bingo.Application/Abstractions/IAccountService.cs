using Bingo.Application.Dtos.User;
using Bingo.Application.Types;

namespace Bingo.Application.Abstractions;

public interface IAccountService
{
    Task<ServiceResult<bool>> RegisterAsync(UserCreateDto dto, CancellationToken cancellationToken);
}