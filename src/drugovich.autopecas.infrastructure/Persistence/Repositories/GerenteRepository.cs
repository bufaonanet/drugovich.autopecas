using drugovich.autopecas.application.Contracts.Repositories;
using drugovich.autopecas.core;
using Microsoft.EntityFrameworkCore;

namespace drugovich.autopecas.infrastructure.Persistence.Repositories;

public class GerenteRepository : GenericRepository<Gerente>, IGerenteRepository
{
    public GerenteRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Gerente> GetClienteByEmailAsync(string email)
    {
        return await _context.Gerentes
            .Where(g => g.Email == email)
            .FirstOrDefaultAsync();
    }
}