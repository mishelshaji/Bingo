using Bingo.Application.Abstractions;
using Bingo.Application.Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace Bingo.WebApi.Controllers;

public class AccountsController(IAccountService service): ApplicationControllerBase
{
    [HttpPost("Register")]
    public async Task<IActionResult> CreateUserAsync([FromBody]UserCreateDto dto, CancellationToken cancellationToken)
    {
        var res = await service.RegisterAsync(dto, cancellationToken);
        return ToActionResult(res);
    }
    
    [HttpPost("Authenticate")]
    public async Task<IActionResult> AuthenticateUserAsync([FromBody]UserLoginRequestDto dto, CancellationToken cancellationToken)
    {
        var res = await service.AuthenticateAsync(dto, cancellationToken);
        return ToActionResult(res);
    }
}