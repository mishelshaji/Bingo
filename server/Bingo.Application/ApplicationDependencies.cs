using Bingo.Application.Abstractions;
using Bingo.Application.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Bingo.Application;

/// <summary>
/// Registers all application layer services with the dependency injection container.
/// </summary>
public static class ApplicationDependencies
{
    /// <summary>
    /// Registers the application services and validators.
    /// </summary>
    /// <param name="services">
    /// The application's service collection.
    /// </param>
    /// <returns>
    /// The updated service collection.
    /// </returns>
    public static IServiceCollection Register(IServiceCollection services)
    {
        // Automatically registers all FluentValidation validators
        // found in the current assembly.
        services.AddValidatorsFromAssemblyContaining(typeof(ApplicationDependencies));

        // Registers the CategoryService so it can be injected
        // wherever ICategoryService is requested.
        services.AddScoped<ICategoryService, CategoryService>();

        // Registers the ContactRequestService.
        services.AddScoped<IContactRequestService, ContactRequestService>();

        // Registers the CountryService.
        services.AddScoped<ICountryService, CountryService>();

        // Registers the StateService.
        services.AddScoped<IStateService, StateService>();

        // Registers the ProductService.
        services.AddScoped<IProductService, ProductService>();
        
        // Registers the AccountService
        services.AddScoped<IAccountService, AccountService>();

        // Returns the updated service collection.
        return services;
    }
}