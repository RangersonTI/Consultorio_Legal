using Core.Domain;
using Data.Context;
using Manager;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository;

public class ClienteRepository: IClienteRepository
{
    private readonly ClContext clContext;
    public ClienteRepository(ClContext clContext)
    {
        this.clContext = clContext;
    }

    public async Task<IEnumerable<Cliente>> GetClientesAsync()
    {
        return await clContext.Clientes.AsNoTracking().ToListAsync();
    }

    public async Task<Cliente> GetClienteByIdAsync(int id)
    {
        // Uso comum
        // return await context.Clientes.AsNoTracking().Where( c => c.Id == id).ToListAsync();

        // Retorna o unico elemento ou retorna um erro caso tenha mais de um item
        // return await context.Clientes.SingleOrDefaultAsync( c => c.Id == id)();
        
        // Verica primeiramente o item em memoria, melhora de desempenho
        return  await clContext.Clientes.FindAsync(id);
    }

}
