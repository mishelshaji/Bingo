using Bingo.Application.Types;
using Bingo.Core.Domains;

namespace Bingo.Application.Abstractions;

public interface ITokenService
{
    ServiceResult<string> CreateToken(ApplicationUser user, IEnumerable<string> roles);
}