using Bingo.Application.Abstractions;
using Bingo.Application.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Bingo.Application;

public static class ApplicationDependencies
{
    public static IServiceCollection Register(IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining(typeof(ApplicationDependencies));
        
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IContactRequestService, ContactRequestService>();
        services.AddScoped<IContactMessageService, ContactMessageService>();
        services.AddScoped<ICountryService, CountryService>();
        return services;
    }
}