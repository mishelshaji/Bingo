using Bingo.Application.Abstractions;
using Bingo.Application.Dtos.Country;
using Microsoft.AspNetCore.Mvc;

namespace Bingo.WebApi.Controllers;

public class CountriesController(ICountryService service): ApplicationControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CountryCreateDto dto, CancellationToken cancellationToken)
    {
        var res = await service.CreateAsync(dto, cancellationToken);
        return Ok(res);
    }
}