using drugovich.autopecas.application.Contracts.Repositories;
using drugovich.autopecas.core;
using Microsoft.EntityFrameworkCore;

namespace drugovich.autopecas.infrastructure.Persistence.Repositories;

public class GrupoRepository : GenericRepository<Grupo>, IGrupoRepository
{
    public GrupoRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IReadOnlyCollection<Grupo>> GetAllAsync(string query)
    {
        if (!string.IsNullOrWhiteSpace(query))
        {
            return await _context.Grupos
                .AsNoTracking()
                .Where(g => g.Nome.Contains(query))
                .ToListAsync();
        }

        return await base.GetAllAsync();
    }
}