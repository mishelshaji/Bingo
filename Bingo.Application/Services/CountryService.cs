using Bingo.Application.Abstractions;
using Bingo.Application.Dtos.Country;
using Bingo.Application.Types;
using Bingo.Core.Domains;
using Bingo.Infrastructure.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Bingo.Application.Services;

public class CountryService(ApplicationDbContext db, 
    IValidator<CountryCreateDto> createDtoValidator): ICountryService
{
    private readonly IQueryable<Country> _countries = db.Countries
        .Where(c => c.DeletedAt == null);
    
    public async Task<ServiceResult<IEnumerable<CountryViewDto>>> GetAllAsync(CancellationToken cancellationToken)
    {
        var countries = await _countries
            .Select(c=>new CountryViewDto()
            {
                Id = c.Id,
                Name = c.Name,
                IsoCode = c.IsoCode,
                PhoneCode = c.PhoneCode,
                States = null
            }).ToArrayAsync(cancellationToken);

        return ServiceResult<IEnumerable<CountryViewDto>>.SuccessResult(countries);
    }

    public async Task<ServiceResult<CountryViewDto?>> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        var country = await _countries
            .Select(c=>new CountryViewDto()
            {
                Id = c.Id,
                Name = c.Name,
                IsoCode = c.IsoCode,
                PhoneCode = c.PhoneCode,
                States = null
            }).FirstOrDefaultAsync(c=>c.Id == id, cancellationToken);
        
        if (country == null)
            return ServiceResult<CountryViewDto?>.NotFoundResult();

        return ServiceResult<CountryViewDto?>.SuccessResult(country);
    }

    public async Task<ServiceResult<CountryViewDto?>> CreateAsync(CountryCreateDto dto, CancellationToken cancellationToken)
    {
        // [
        //  { Property = 'Name', ErrorMessage = 'Error Message 1'},
        //  
        // ]
        var validationResult = await createDtoValidator.ValidateAsync(dto, cancellationToken);
        if (!validationResult.IsValid)
            return ServiceResult<CountryViewDto?>.ValidationErrorResult(validationResult.Errors.Select(e=>e.ErrorMessage));
        return ServiceResult<CountryViewDto?>.CreatedResult(new ());
    }

    public Task<ServiceResult<CountryViewDto?>> UpdateAsync(long id, CountryCreateDto dto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResult<bool>> DeleteAsync(long id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}