using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

        return services;
    }
}
