using System.Reflection;
using drugovich.autopecas.core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace drugovich.autopecas.infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    private readonly ILogger<ApplicationDbContext> _logger;

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        ILogger<ApplicationDbContext> logger) : base(options)
    {
        _logger = logger;
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Gerente> Gerentes { get; set; }
    public DbSet<Grupo> Grupos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public async Task SeedDb()
    {
        try
        {
            var databaseExists = await Database.CanConnectAsync();
            if (!databaseExists)
            {
                await Database.EnsureCreatedAsync();
                _logger.LogInformation($"Criando o banco de dados");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Um erro ocorreu ao executar as migrações.");
        }
    }
}