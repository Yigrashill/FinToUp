using Application.Contracts.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Repositories;

namespace Persistance;

public static class PersistanceServiceRegestration 
{
    public static IServiceCollection AddPersistanceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<FinanceDataBaseContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("FinanceConnectionString"));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericReporitory<>));
        services.AddScoped<IFinanceRepository, FinanceRepository> ();

        return services;
    }
}
