using System;
using Core.Domain;

namespace Manager{
    public interface IClienteRepository
    {
        Task<Cliente> GetClienteByIdAsync(int id);

        Task<IEnumerable<Cliente>> GetClientesAsync();
    }
}

