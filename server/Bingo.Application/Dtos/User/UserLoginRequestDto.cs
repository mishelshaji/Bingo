using FluentValidation;

namespace Bingo.Application.Dtos.User;

public class UserLoginRequestDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public class UserLoginRequestDtoValidator : AbstractValidator<UserLoginRequestDto>
{
    public UserLoginRequestDtoValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is invalid")
            .MinimumLength(5).WithMessage("Email must be at least 5 characters long")
            .MaximumLength(150).WithMessage("Email must not exceed 150 characters");
        
        RuleFor(x=>x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(6).WithMessage("Password must be at least 5 characters long")
            .MaximumLength(50).WithMessage("Password must not exceed 150 characters");
    }
}