using drugovich.autopecas.core;

namespace drugovich.autopecas.application.Contracts.Repositories;

public interface IGrupoRepository : IGenericRepository<Grupo>
{
    Task<IReadOnlyCollection<Grupo>> GetAllAsync(string query);
}