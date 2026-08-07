using System.Text;
using Bingo.Core.Domains;
using Bingo.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace Bingo.Infrastructure;

/// <summary>
/// Registers all infrastructure services required by the application.
/// </summary>
public static class InfrastructureDependencies
{
    /// <summary>
    /// Registers infrastructure services with the dependency injection container.
    /// </summary>
    /// <param name="services">
    /// The application's service collection.
    /// </param>
    /// <param name="configuration">
    /// Provides access to the application's configuration values.
    /// </param>
    /// <returns>
    /// The updated service collection.
    /// </returns>
    public static IServiceCollection Register(IServiceCollection services, IConfigurationManager configuration)
    {
        // Retrieves the database connection string from appsettings.json.
        var connStr = configuration.GetConnectionString("DefaultConnection");

        // Registers the ApplicationDbContext with the dependency injection container.
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            // Configures Entity Framework Core to use SQL Server as the database provider.
            options.UseSqlServer(connStr,
                sqlOptions =>
                {
                    // Specifies that EF Core migrations are stored in the Bingo.Infrastructure assembly.
                    sqlOptions.MigrationsAssembly("Bingo.Infrastructure");
                });
        });

        services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._";
            })
            .AddEntityFrameworkStores<ApplicationDbContext>();

        var key = Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]);
        var signingKey = new SymmetricSecurityKey(key);
        
        var issuer = configuration["JwtSettings:Issuer"];
        var audience = configuration["JwtSettings:Audience"];
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            // options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.MapInboundClaims = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateLifetime = false,
                IssuerSigningKey = signingKey,
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidAudience = audience,
                ValidIssuer = issuer,
                RoleClaimType = "role",
                NameClaimType = JwtRegisteredClaimNames.Name,
                ClockSkew = TimeSpan.Zero,
            };
        });
        
        services.AddAuthorization();
        // Returns the updated service collection so additional services can be registered.
        return services;
    }
}