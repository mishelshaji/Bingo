using Microsoft.AspNetCore.Identity;

namespace Bingo.Core.Domains;

public class ApplicationUser: IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}