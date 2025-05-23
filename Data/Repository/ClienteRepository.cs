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

    // POST
    public async Task<Cliente> InsertClienteAsync(Cliente cliente)
    {
        await clContext.Clientes.AddAsync(cliente);
        await clContext.SaveChangesAsync();
        return cliente;
    }

    // PUT
    public async Task<Cliente> UpdateClienteAsync(Cliente cliente)
    {
        var clienteConsultado = await clContext.Clientes.FindAsync(cliente.Id);

        if(clienteConsultado == null)
        {
            return null;
        }
        
        // CASO UM OBJETO A SER ATRIBUIDO UMA FUNÇÃO JÁ TENHA SIDO ATRIBIDA A UMA OUTRA QUE UTILIZE O TRACKING,
        // SERÁ NESSA CRIAR UM NOME OBJETO ATRIBUINDO SEUS VALORES A ELE PARA ASSIM CONSEGUIR ATRIBUIR ESSE VALORES
        // A FUNÇÃO ESTINADA. PODE SER FEITA MANUALMENTE

        // clienteConsultado.DataNascimento = cliente.DataNascimento;
        // clienteConsultado.Nome = cliente.Nome;
        // clContext.Clientes.Update(clienteConsultado);

        // OU PODE UTILIZAR O 'ENTRY' PARA ATRIBUILO, ONDE CAMPO DO VALOR DO MESMO TIPO SÃO ATRIBUIDO,
        // E OUTROS SÃO IGNORADOS

        clContext.Entry(clienteConsultado).CurrentValues.SetValues(cliente);

        await clContext.SaveChangesAsync();
        return clienteConsultado;
    }

    //DELETE
    public async Task DeleteClienteAsync(int id)
    {
        var clienteConsultado = await clContext.Clientes.FindAsync(id);

        if(clienteConsultado != null)
        {
            clContext.Clientes.Remove(clienteConsultado);
            await clContext.SaveChangesAsync();
        }
    }

}
