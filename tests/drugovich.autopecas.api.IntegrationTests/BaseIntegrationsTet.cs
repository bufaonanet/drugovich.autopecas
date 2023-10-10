using drugovich.autopecas.infrastructure.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace drugovich.autopecas.api.IntegrationTests;

public abstract class BaseIntegrationsTet : IClassFixture<IntegrationTestsWebAppFactory>
{
    private readonly IServiceScope _scope;
    protected readonly ISender Sender;
    protected readonly ApplicationDbContext DbContext;

    protected BaseIntegrationsTet(IntegrationTestsWebAppFactory factory)
    {
        _scope = factory.Services.CreateScope();
        
        Sender = _scope.ServiceProvider.GetRequiredService<ISender>();
        DbContext = _scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        DbContext.Database.EnsureCreated();
    }
}