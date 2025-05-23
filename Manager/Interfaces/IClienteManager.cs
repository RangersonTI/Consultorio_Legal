using Core.Domain;

namespace Manager;

public interface IClienteManager
{
    Task<IEnumerable<Cliente>> GetClientesAsync();
    Task<Cliente> GetClienteByIdAsync(int id);
    Task<Cliente> InsertClienteAsync(Cliente cliente);
    Task<Cliente> UpdateClienteAsync(Cliente cliente);
    Task DeleteClienteAsync(int id);
}
