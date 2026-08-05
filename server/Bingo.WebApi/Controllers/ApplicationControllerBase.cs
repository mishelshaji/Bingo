using Bingo.Application.Types;
using Microsoft.AspNetCore.Mvc;

namespace Bingo.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public abstract class ApplicationControllerBase: ControllerBase
{
    protected IActionResult ToActionResult<TData>(ServiceResult<TData> result)
    {
        switch (result.ResultType)
        {
            case ResultType.Success:
            case ResultType.Created:
            case ResultType.Updated:
            case ResultType.Deleted:
                return Ok(result);
            case ResultType.ValidationError:
                return BadRequest(result);
            case ResultType.PermissionDenied:
                return Unauthorized(result);
            case ResultType.NotFound:
                return NotFound(result);
            case ResultType.Error:
            default:
                throw new Exception(result.Message ?? "An error occured");
        }
    }
}
