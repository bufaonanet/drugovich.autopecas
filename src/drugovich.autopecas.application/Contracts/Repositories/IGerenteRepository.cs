using drugovich.autopecas.core;

namespace drugovich.autopecas.application.Contracts.Repositories;

public interface IGerenteRepository : IGenericRepository<Gerente>
{
    Task<Gerente> GetClienteByEmailAsync(string email);
}