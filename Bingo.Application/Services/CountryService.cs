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
    private readonly IQueryable<Country> _baseQuery = db.Countries
        .Where(c => c.DeletedAt == null);
    
    public async Task<ServiceResult<IEnumerable<CountryViewDto>>> GetAllAsync(CancellationToken cancellationToken)
    {
        var countries = await _baseQuery
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
        var country = await _baseQuery
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
        var validationResult = await createDtoValidator.ValidateAsync(dto, cancellationToken);
        if (!validationResult.IsValid)
            return ServiceResult<CountryViewDto?>.ValidationErrorResult(validationResult.Errors.Select(e=>e.ErrorMessage));

        var countryExists = await _baseQuery
            .AnyAsync(c => c.Name == dto.Name || c.IsoCode == dto.IsoCode, cancellationToken);
        
        if(countryExists)
            return ServiceResult<CountryViewDto?>.ValidationErrorResult(["Country already exists."]);

        var country = new Country()
        {
            Name = dto.Name,
            IsoCode = dto.IsoCode,
            PhoneCode = dto.PhoneCode,
        };
        await db.Countries.AddAsync(country, cancellationToken);
        await db.SaveChangesAsync(cancellationToken);
        
        return ServiceResult<CountryViewDto?>.CreatedResult(new  CountryViewDto()
        {
            Id = country.Id,
            Name = country.Name,
            IsoCode = country.IsoCode,
            PhoneCode = country.PhoneCode,
        });
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