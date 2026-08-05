using Bingo.Application.Abstractions;
using Bingo.Application.Dtos.State;
using Bingo.Application.Types;
using Microsoft.AspNetCore.Mvc;

namespace Bingo.WebApi.Controllers;

public class StatesController(IStateService service): ApplicationControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(ServiceResult<StateViewDto[]>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
    {
        var res = await service.GetAllAsync(cancellationToken);
        return ToActionResult(res);
    }

    [HttpGet("{id:long}")]
    [ProducesResponseType(typeof(ServiceResult<StateViewDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAsync([FromRoute] long id, CancellationToken cancellationToken)
    {
        var res = await service.GetByIdAsync(id, cancellationToken);
        return ToActionResult(res);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(ServiceResult<StateViewDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAsync([FromBody] StateCreateDto dto, CancellationToken cancellationToken)
    {
        var res = await service.CreateAsync(dto, cancellationToken);
        return ToActionResult(res);
    }
}