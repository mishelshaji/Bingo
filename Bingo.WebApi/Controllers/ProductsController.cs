using Bingo.Application.Dtos.Product;
using Microsoft.AspNetCore.Mvc;

namespace Bingo.WebApi.Controllers;

public class ProductsController: ApplicationControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody]ProductCreateDto dto, CancellationToken cancellationToken)
    {
        return Ok(dto);
    }
}