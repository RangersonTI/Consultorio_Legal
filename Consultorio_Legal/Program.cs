using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

// CONFIGURA A LEITURA DO appsettings.json
IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddDbContext<ClContext>(options => options.UseSqlServer(configuration.GetConnectionString("ClConnection")));

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

app.UseHttpsRedirection();

app.UseAuthentication();

app.Run();