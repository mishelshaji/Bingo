using Bingo.Application.Abstractions;
using Bingo.Application.Dtos.ContactMessage;
using Bingo.Application.Types;
using Microsoft.AspNetCore.Mvc;

namespace Bingo.WebApi.Controllers;

public class ContactMessageController(IContactMessageService service): ApplicationControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody]ContactMessageCreateDto dto, CancellationToken cancellationToken)
    {
        var res = await service.CreateAsync(dto, cancellationToken);
        switch (res.ResultType)
        {
            case ResultType.ValidationError:
                return BadRequest(res);
            case ResultType.Created:
                return Ok(res);
            default:
                return BadRequest(res);
        }
    }
}