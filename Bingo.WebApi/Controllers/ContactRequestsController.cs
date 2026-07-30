using Bingo.Application.Abstractions;
using Bingo.Application.Dtos.ContactRequest;
using Bingo.Application.Types;
using Microsoft.AspNetCore.Mvc;

namespace Bingo.WebApi.Controllers;

public class ContactRequestsController(IContactRequestService service): ApplicationControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync(ContactRequestCreateDto dto, CancellationToken cancellationToken)
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