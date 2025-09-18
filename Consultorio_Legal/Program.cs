
using Consultorio_Legal.Configuration;
using Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddFluentValidationConfiguration();

builder.Services.AddAutoMapperConfiguration();

builder.Services.AddDataBaseConfiguration(builder.Configuration);

builder.Services.AddDepencyInjectorConfiguration();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfiguration();
    app.UseDeveloperExceptionPage();
}

app.MapControllers();

// Serve os arquivos de React
// app.UseDefaultFiles(); // busca o index.html
// app.UseStaticFiles(); // serve tudo de wwwroot

// Fallback para SPA: qualquer rota não-API vai para index.html
// app.MapFallbackToFile("futcrente/index.html");

app.UseSwaggerConfiguration();

// app.UseHttpsRedirection();

// app.UseAuthentication();

app.Run("http://0.0.0.0:7000");