using drugovich.autopecas.core.Common;

namespace drugovich.autopecas.application.Contracts.Repositories;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<IReadOnlyCollection<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}