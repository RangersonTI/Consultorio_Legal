
using Core.Domain;

namespace Manager.Implementation;

public class ClienteManager: IClienteManager
{      
    private readonly IClienteRepository clienteRepository;
    public ClienteManager(IClienteRepository clienteRepository)
    {
        this.clienteRepository = clienteRepository;
    }

    public async Task<IEnumerable<Cliente>> GetClientesAsync()
    {
        return await clienteRepository.GetClientesAsync();
    }

    public async Task<Cliente> GetClienteByIdAsync(int id)
    {
        return await clienteRepository.GetClienteByIdAsync(id);
    }
}
