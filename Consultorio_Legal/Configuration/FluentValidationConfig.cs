using System;
using System.Globalization;
using Core.Shared.ModelViews;
using FluentValidation.AspNetCore;
using Manager.Validator;

namespace Consultorio_Legal.Configuration;

public static class FluentValidationConfig
{
    public static void AddFluentValidationConfiguration(this IServiceCollection services)
    {
        services.AddControllers().AddFluentValidation(v =>
            {
                v.RegisterValidatorsFromAssemblyContaining<NovoClienteValidator>();
                v.RegisterValidatorsFromAssemblyContaining<AlteraClienteValidator>();
                v.ValidatorOptions.LanguageManager.Culture = new CultureInfo("PT-BR");
            }
        );
    }
}
