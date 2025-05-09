using Core.Domain;

namespace Manager;

public interface IClienteManager
{
    Task<IEnumerable<Cliente>> GetClientesAsync();
    Task<Cliente> GetClienteByIdAsync(int id);
}
