using System;
using Data.Repository;
using Manager;
using Manager.Implementation;

namespace Consultorio_Legal.Configuration;

public static class DependencyInjectorConfig
{
    public static void UseDepencyInjectorConfiguration(this IServiceCollection services)
    {
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IClienteManager, ClienteManager>();
    }
}
