using Bingo.Application.Abstractions;
using Bingo.Application.Dtos.User;
using Bingo.Application.Types;
using Bingo.Core.Domains;
using Microsoft.AspNetCore.Identity;

namespace Bingo.Application.Services;

public class AccountService: IAccountService
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public AccountService(
        RoleManager<IdentityRole> roleManager,
        UserManager<ApplicationUser> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
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
}