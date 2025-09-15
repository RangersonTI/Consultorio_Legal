using System;
using System.Reflection;
using Microsoft.OpenApi.Models;

namespace Consultorio_Legal.Configuration;

public static class SwaggerConfig
{   
    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(
            s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API Consultório Legal",
                    Version = "v1",
                    Description = "API da aplicação Consultório Legal!",
                    Contact = new OpenApiContact
                    {
                        Name = "Rangerson Clemente",
                        Email = "rangerson14@outlook.com",
                        Url = new Uri("https://github.com/RangersonTI"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "OSD",
                        Url = new Uri("https://opensource.org/osd")
                    },
                    TermsOfService = new Uri("https://opensource.org/osd")
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                s.IncludeXmlComments(xmlPath);
                xmlPath = Path.Combine(AppContext.BaseDirectory, "Core.Shared.xml");
                s.IncludeXmlComments(xmlPath);
        });
    }

    // ISERVICES -> ADD 
    // CONFIGURE -> USE

    public static void UseSwaggerConfiguration(this IApplicationBuilder app)
    {
        app.UseSwagger();

        app.UseSwaggerUI(
            a =>
            {
                a.RoutePrefix = string.Empty;
                a.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            }
        );

    }
}
