using Bingo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

        // Returns the updated service collection so additional services can be registered.
        return services;
    }
}