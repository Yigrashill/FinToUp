using Application.Contracts.Logging;
using AutoMapper;
using Infrastructure.Looging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;


namespace Infrastructure;

public static class InfrastucutreServiceRegestration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IAppLogger<>), typeof(AppLogger<>));

        return services;
    }
}
