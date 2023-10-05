using drugovich.autopecas.core;

namespace drugovich.autopecas.application.Contracts.Repositories;

public interface IClienteRepository : IGenericRepository<Cliente>
{
    Task<IReadOnlyCollection<Cliente>> GetAllClientesWithGruposAsync(string query);
    Task<Cliente> GetClienteByIdWIthGrupoAsync(int id);
}