using System.Security.Claims;
using System.Text;
using Bingo.Application.Abstractions;
using Bingo.Application.Types;
using Bingo.Core.Domains;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace Bingo.Application.Services;

public class TokenService(IConfiguration configuration): ITokenService
{
    public ServiceResult<string> CreateToken(ApplicationUser user, IEnumerable<string> roles)
    {
        var key = configuration["JwtSettings:Key"];
        var issuer = configuration["JwtSettings:Issuer"];
        var audience = configuration["JwtSettings:Audience"];
        var expiryInMinutes = int.Parse(configuration["JwtSettings:ExpiryInMinutes"]);
        var expiry = DateTime.UtcNow.AddMinutes(expiryInMinutes);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id),
            new(JwtRegisteredClaimNames.Email, user.Email),
            new(JwtRegisteredClaimNames.Name, $"{user.FirstName} {user.LastName}"),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        
        var roleClaims = roles.Select(r=>new Claim("role", r)).ToList();
        claims.AddRange(roleClaims);
        
        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
        
        var descriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = expiry,
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = credentials
        };

        var handler = new JsonWebTokenHandler();
        var token = handler.CreateToken(descriptor);

        return ServiceResult<string>.SuccessResult(token);
    }
}