using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Context{
    public class ClContext: DbContext
    {
        public DbSet<Cliente> Clientes {get; set;}
        public ClContext(DbContextOptions options) : base(options){
            
        }
    }

}

