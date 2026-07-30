using FluentValidation;

namespace Bingo.Application.Dtos.State;

public class StateCreateDto
{
    public string Name { get; set; }
    public string IsoCode { get; set; }
    public long CountryId { get; set; }
}

public class StateCreateDtoValidator : AbstractValidator<StateCreateDto>
{
    public StateCreateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name cannot be empty.")
            .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
            .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.");

        RuleFor(x=>x.IsoCode)
            .NotEmpty().WithMessage("IsoCode cannot be empty.")
            .MinimumLength(2).WithMessage("IsoCode must be at least 2 characters.")
            .MaximumLength(10).WithMessage("IsoCode cannot exceed 10 characters.");
        
        RuleFor(x => x.CountryId)
            .NotEmpty().WithMessage("CountryId cannot be empty.");
    }
}