using Bingo.Application.Abstractions;
using Bingo.Application.Dtos.State;
using Bingo.Application.Types;
using Bingo.Core.Domains;
using Bingo.Infrastructure.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Bingo.Application.Services;

public class StateService(ApplicationDbContext db, IValidator<StateCreateDto> validator): IStateService
{
    private readonly IQueryable<State> _baseQuery = db.States
        .Where(s => s.DeletedAt == null);
    
    public async Task<ServiceResult<IEnumerable<StateViewDto>>> GetAllAsync(CancellationToken cancellationToken)
    {
        var result = await _baseQuery
            .Select(s=>new StateViewDto
            {
                Id = s.Id,
                Name = s.Name,
                IsoCode = s.IsoCode,
                CountryId = s.CountryId,
            }).ToListAsync(cancellationToken);
        
        return ServiceResult<IEnumerable<StateViewDto>>.SuccessResult(result);
    }

    public Task<ServiceResult<StateViewDto?>> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResult<StateViewDto?>> CreateAsync(StateCreateDto dto, CancellationToken cancellationToken)
    {
        var validationResult = new StateCreateDtoValidator().Validate(dto);
        if (!validationResult.IsValid)
            return ServiceResult<StateViewDto?>.ValidationErrorResult(validationResult.Errors.Select(e => e.ErrorMessage));

        var stateExists = await db.States
            .AnyAsync(s => s.IsoCode == dto.IsoCode, cancellationToken);
        
        if(stateExists)
            return ServiceResult<StateViewDto?>.ValidationErrorResult(["State already exists."]);

        var countryExists = await db.Countries
            .AnyAsync(s => s.Id == dto.CountryId, cancellationToken);
        if(!countryExists)
            return ServiceResult<StateViewDto?>.ValidationErrorResult(["Country does not exist."]);
        
        var state = new State()
        {
            Name = dto.Name,
            IsoCode = dto.IsoCode,
            CountryId = dto.CountryId
        };
        await db.States.AddAsync(state, cancellationToken);
        await db.SaveChangesAsync(cancellationToken);
        
        return ServiceResult<StateViewDto?>.CreatedResult(new()
        {
            Id = state.Id,
            Name = state.Name,
            IsoCode = state.IsoCode,
            CountryId = state.CountryId
        });
    }

    public Task<ServiceResult<StateViewDto?>> UpdateAsync(long id, StateCreateDto dto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResult<bool>> DeleteAsync(long id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}