using drugovich.autopecas.core;
using Microsoft.EntityFrameworkCore;

namespace drugovich.autopecas.infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Gerente> Gerentes { get; set; }
    public DbSet<Grupo> Grupos { get; set; }
}