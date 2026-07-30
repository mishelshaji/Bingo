using Bingo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bingo.Infrastructure;

public static class InfrastructureDependencies
{
    public static IServiceCollection Register(IServiceCollection services, IConfigurationManager configuration)
    {
        var connStr = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connStr, 
                b=>b.MigrationsAssembly("Bingo.Infrastructure"));
        });

        return services;
    }
}
