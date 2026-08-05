using Bingo.Application.Dtos.Tag;
using Bingo.Application.Types;
using Bingo.Core.Domains;
using Bingo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Bingo.Application.Services;

public class TagService(ApplicationDbContext db)
{
    private readonly IQueryable<Tag> _tags = db.Tags
        .Where(t => t.DeletedAt == null);
    
    public async Task<ServiceResult<TagViewDto[]>> GetAllAsync(CancellationToken cancellationToken)
    {
        var tags = await _tags.Select(t=> new TagViewDto()
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
            })
            .ToArrayAsync(cancellationToken);
        
        return ServiceResult<TagViewDto[]>.SuccessResult(tags);
    }

    public async Task<ServiceResult<TagViewDto?>> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        var tag = await _tags
            .Select(t=> new TagViewDto()
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
            })
            .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
        
        if(tag == null)
            return ServiceResult<TagViewDto?>.NotFoundResult();
        
        return ServiceResult<TagViewDto?>.SuccessResult(tag);
    }
}