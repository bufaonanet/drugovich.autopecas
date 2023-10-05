using drugovich.autopecas.application.Contracts.Repositories;
using drugovich.autopecas.core;
using Microsoft.EntityFrameworkCore;

namespace drugovich.autopecas.infrastructure.Persistence.Repositories;

public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
{
    public ClienteRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IReadOnlyCollection<Cliente>> GetAllClientesWithGruposAsync(string query)
    {
        if (!string.IsNullOrWhiteSpace(query))
        {
            return await _context.Clientes
                .AsNoTracking()
                .Include(c => c.Grupo)
                .Where(g => g.Nome.Contains(query))
                .ToListAsync();
        }

        return await _context.Clientes
            .AsNoTracking()
            .Include(c => c.Grupo)
            .ToListAsync();
    }

    public async Task<Cliente> GetClienteByIdWIthGrupoAsync(int id)
    {
        return await _context.Clientes
            .Include(c => c.Grupo)
            .FirstAsync(c => c.Id == id);
    }
}