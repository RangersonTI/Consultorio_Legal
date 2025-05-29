using Core.Domain;
using Core.Shared.ModelViews;

namespace Manager;

public interface IClienteManager
{
    Task<IEnumerable<Cliente>> GetClientesAsync();
    Task<Cliente> GetClienteByIdAsync(int id);
    Task<Cliente> InsertClienteAsync(NovoCliente novoCliente);
    Task<Cliente> UpdateClienteAsync(AlteraCliente cliente);
    Task DeleteClienteAsync(int id);
}
