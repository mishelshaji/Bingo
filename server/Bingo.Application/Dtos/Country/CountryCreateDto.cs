using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Bingo.Application.Dtos.Country;

public class CountryCreateDto
{
    public string Name { get; set; }
    public string IsoCode { get; set; }
    public string PhoneCode { get; set; }
}

public class CountryCreateDtoValidator : AbstractValidator<CountryCreateDto>
{
    public CountryCreateDtoValidator()
    {
        RuleFor(p=>p.Name)
            .NotEmpty().WithMessage("Name cannot be empty")
            .MaximumLength(100).WithMessage("Name cannot be longer than 50 characters")
            .MinimumLength(2).WithMessage("Name cannot be less than 2 characters");
        
        RuleFor(p=>p.IsoCode)
            .NotEmpty().WithMessage("IsoCode cannot be empty")
            .MaximumLength(3).WithMessage("IsoCode cannot be longer than 3 characters")
            .MinimumLength(2).WithMessage("IsoCode cannot be less than 2 characters");
        
        RuleFor(p=>p.PhoneCode)
            .NotEmpty().WithMessage("PhoneCode cannot be empty")
            .MaximumLength(3).WithMessage("PhoneCode cannot be longer than 3 characters")
            .MinimumLength(2).WithMessage("PhoneCode cannot be less than 2 characters");
        
    }
}