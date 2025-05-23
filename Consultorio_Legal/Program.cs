using System.Globalization;
using Data.Context;
using Data.Repository;
using FluentValidation.AspNetCore;
using Manager;
using Manager.Implementation;
using Manager.Validator;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddFluentValidation(v => 
    {
        v.RegisterValidatorsFromAssemblyContaining<ClienteValidator>();
        v.ValidatorOptions.LanguageManager.Culture = new CultureInfo("PT-BR");
    });

builder.Services.AddDbContext<ClContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("ClConnection"))
);

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

builder.Services.AddScoped<IClienteManager, ClienteManager>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(
    c =>{
        c.SwaggerDoc("v1", new OpenApiInfo 
        {
            Title="API Consultorio Legal",
            Version="v1"
        });
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapControllers();

app.UseSwagger();

app.UseSwaggerUI(
    c => {
        c.RoutePrefix = string.Empty;
        c.SwaggerEndpoint("/swagger/v1/swagger.json","v1");
    }
);

// app.UseHttpsRedirection();

// app.UseAuthentication();

app.Run();