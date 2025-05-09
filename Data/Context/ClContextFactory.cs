using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Data.Context
{
    public class ClContextFactory: IDesignTimeDbContextFactory<ClContext>
    {
        public ClContext CreateDbContext(string[] args){
            var path = Path.Combine(Directory.GetCurrentDirectory(),"..","Consultorio_Legal");

            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json")
                .Build();
            
            var optionBuilder = new DbContextOptionsBuilder<ClContext>();
            optionBuilder.UseSqlServer(config.GetConnectionString("ClConnection"));

            return new ClContext(optionBuilder.Options);
        }
    }
}

    // public class ClContextFactory : IDesignTimeDbContextFactory<ClContext>
    // {
    //     public ClContext CreateDbContext(string[] args)
    //     {
    //         var path = Path.Combine(Directory.GetCurrentDirectory(),"..","Consultorio_Legal");

    //         IConfiguration config = new ConfigurationBuilder()
    //             .SetBasePath(path)
    //             .AddJsonFile("appsettings.json")
    //             .Build();

    //         var optionsBuilder = new DbContextOptionsBuilder<ClContext>();
    //         optionsBuilder.UseSqlServer(config.GetConnectionString("ClConnection"));

    //         return new ClContext(optionsBuilder.Options);
    //     }
    // }