using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Consultorio_Legal.Configuration;

public static class DataBaseConfig
{
    public static void AddDataBaseConfiguration(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<ClContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ClConnectionTrab"))
        );
    }

    public static void UseDataBaseConfiguration(this IApplicationBuilder app)
    {
        var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var context = serviceScope.ServiceProvider.GetService<ClContext>();

        context.Database.Migrate();
    }
}
