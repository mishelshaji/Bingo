using Bingo.Application.Abstractions;
using Bingo.Application.Dtos.Product;
using Microsoft.AspNetCore.Mvc;

namespace Bingo.WebApi.Controllers;

public class ProductsController(IProductService productService): ApplicationControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var res = await productService.GetAllAsync(cancellationToken);
        return ToActionResult(res);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody]ProductCreateDto dto, CancellationToken cancellationToken)
    {
        var res = await productService.CreateAsync(dto, cancellationToken);
        return ToActionResult(res);
    }
    
    
}