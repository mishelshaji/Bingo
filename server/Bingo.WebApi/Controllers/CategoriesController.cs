using System.Security.Claims;
using Bingo.Application.Abstractions;
using Bingo.Application.Dtos.Category;
using Bingo.Application.Types;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Bingo.WebApi.Controllers;

[Authorize]
public class CategoriesController(ICategoryService categoryService): ApplicationControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(ServiceResult<CategoryViewDto[]>),StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var res = await categoryService.GetAllAsync(cancellationToken);
        return ToActionResult(res);
    }
    
    [HttpGet("{id:long}")]
    [ProducesResponseType(typeof(ServiceResult<CategoryViewDto?>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync([FromRoute]long id, CancellationToken cancellationToken)
    {
        var res = await categoryService.GetByIdAsync(id, cancellationToken);
        return ToActionResult(res);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody]CategoryCreateDto dto, CancellationToken cancellationToken)
    {
        var res = await categoryService.CreateAsync(dto, cancellationToken);
        return ToActionResult(res);
    }
    
    [HttpPut("{id:long}")]
    public async Task<IActionResult> UpdateAsync([FromRoute]long id, [FromBody]CategoryCreateDto dto, CancellationToken cancellationToken)
    {
        var res = await categoryService.UpdateAsync(id, dto, cancellationToken);
        return ToActionResult(res);
    }
    
    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteAsync([FromRoute]long id, CancellationToken cancellationToken)
    {
        var res = await categoryService.DeleteAsync(id, cancellationToken);
        return ToActionResult(res);
    }
}