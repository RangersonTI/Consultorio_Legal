using System;
using Manager.Mappings;

namespace Consultorio_Legal.Configuration;

public static class AutoMapperonfiguration
{
    public static void AddAutoMapperConfiguration(this IServiceCollection services)
    {   
        services.AddAutoMapper(typeof(NovoClienteMappingProfile), typeof(AlteraClienteMappingProfile));
    }
}
