using FluentValidation;

namespace Bingo.Application.Dtos.Category;

public class CategoryCreateDto
{
    public string Name { get; set; }
    public string Slug { get; set; }
    public string? Description { get; set; }
}

public class CategoryCreateDtoValidator : AbstractValidator<CategoryCreateDto>
{
    public CategoryCreateDtoValidator()
    {
        RuleFor(p=>p.Name)
            .NotEmpty().WithMessage("Name cannot be empty")
            .MaximumLength(50).WithMessage("Name cannot be longer than 50 characters")
            .MinimumLength(2).WithMessage("Name cannot be less than 2 characters");
        
        RuleFor(p=>p.Slug)
            .NotEmpty().WithMessage("Slug cannot be empty")
            .MaximumLength(50).WithMessage("Slug cannot be longer than 50 characters")
            .MinimumLength(2).WithMessage("Slug cannot be less than 2 characters");
        
        RuleFor(p=>p.Description)
            .MaximumLength(500).WithMessage("Description cannot be longer than 500 characters")
            .MinimumLength(2).WithMessage("Description cannot be less than 2 characters");
    }
}