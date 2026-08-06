using Bingo.Application.Abstractions;
using Bingo.Application.Dtos.User;
using Bingo.Application.Types;
using Bingo.Core.Domains;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace Bingo.Application.Services;

public class AccountService: IAccountService
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IValidator<UserLoginRequestDto> _loginRequestValidator;

    public AccountService(
        RoleManager<IdentityRole> roleManager,
        UserManager<ApplicationUser> userManager,
        IValidator<UserLoginRequestDto> loginRequestValidator)
    {
        _roleManager = roleManager;
        _userManager = userManager;
        _loginRequestValidator = loginRequestValidator;
    }
    
    public async Task<ServiceResult<bool>> RegisterAsync(UserCreateDto dto, CancellationToken cancellationToken)
    {
        var roleName = "User";
        var roleExists = await _roleManager.RoleExistsAsync(roleName);
        
        if(!roleExists)
            await _roleManager.CreateAsync(new IdentityRole(roleName));

        var username = Guid.NewGuid().ToString()
            .Replace("-", "");

        var user = new ApplicationUser()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            UserName = username
        };
        
        var userCreationResult = await _userManager.CreateAsync(user, dto.Password);
        if (!userCreationResult.Succeeded)
        {
            var errors = userCreationResult.Errors.Select(e => e.Description);
            return ServiceResult<bool>.ValidationErrorResult(errors);
        }
        
        await _userManager.AddToRoleAsync(user, roleName);
        return ServiceResult<bool>.SuccessResult(true);
    }

    public async Task<ServiceResult<string>> AuthenticateAsync(UserLoginRequestDto dto, CancellationToken cancellationToken)
    {
        var validationResult = await _loginRequestValidator.ValidateAsync(dto, cancellationToken);
        if(!validationResult.IsValid)
            return ServiceResult<string>.ValidationErrorResult(validationResult.Errors.Select(e=>e.ErrorMessage));
        
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if (user == null)
            return ServiceResult<string>.UnauthorizedResult("Invalid details");
        
        var isValidPassword = await _userManager.CheckPasswordAsync(user, dto.Password);
        if (!isValidPassword)
            return ServiceResult<string>.UnauthorizedResult("Invalid details");
        
        return ServiceResult<string>.SuccessResult("hjsgjd.sjhgj.sdfjhgfd");
    }
}