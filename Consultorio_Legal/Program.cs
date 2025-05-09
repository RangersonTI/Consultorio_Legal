using Data.Context;
using Data.Repository;
using Manager;
using Manager.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

// CONFIGURA A LEITURA DO appsettings.json

var builder = WebApplication.CreateBuilder(args);

// var path = Path.Combine(Directory.GetCurrentDirectory(),"..","Consultorio_Legal");

// IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(path).AddJsonFile("appsettings.json").Build();

builder.Services.AddControllers();

builder.Services.AddDbContext<ClContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("ClConnection"))
);

// builder.Services.AddDbContext<ClContext>(options => options.UseSqlServer(configuration.GetConnectionString("ClConnection")));

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