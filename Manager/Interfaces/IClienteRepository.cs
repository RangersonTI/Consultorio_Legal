using System;
using Core.Domain;

namespace Manager{
    public interface IClienteRepository
    {
        Task<Cliente> GetClienteByIdAsync(int id);

        Task<IEnumerable<Cliente>> GetClientesAsync();

        // POST
        Task<Cliente> InsertClienteAsync(Cliente cliente);

        //PUT
        Task<Cliente> UpdateClienteAsync(Cliente cliente);

        //DELETE
        Task DeleteClienteAsync(int id);
    }
}

