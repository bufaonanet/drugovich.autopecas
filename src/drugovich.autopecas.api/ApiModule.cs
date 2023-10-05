using drugovich.autopecas.core;
using drugovich.autopecas.core.Enums;
using drugovich.autopecas.infrastructure.Persistence;
using Microsoft.OpenApi.Models;

namespace drugovich.autopecas.api;

public static class ApiModule
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddControllers();

        services.AddHealthChecks();

        return services;
    }

    public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "drugovich.autopecas.api", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header usando o esquema Bearer."
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
        });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }

    public static async Task SeedDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        try
        {
            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
            if (context != null)
            {
                var listaGrupos = new List<Grupo>
                {
                    new Grupo { Id = 1, Nome = "Grupo 1" },
                    new Grupo { Id = 2, Nome = "Grupo 2" }
                };
                context.Grupos.AddRange(listaGrupos);

                var listaClientes = new List<Cliente>
                {
                    new Cliente
                    {
                        Id = 1, CNPJ = "49341109000181", Nome = "Cliente1",
                        DataFundacao = DateTime.Now.AddYears(-1), GrupoId = 1
                    },
                    new Cliente
                    {
                        Id = 2, CNPJ = "49341109000181", Nome = "Cliente2",
                        DataFundacao = DateTime.Now.AddYears(-1), GrupoId = 2
                    }
                };
                context.Clientes.AddRange(listaClientes);

                var listaGerentes = new List<Gerente>
                {
                    new Gerente
                    {
                        Id = 1, Nome = "gerente1", Email = "gerente1@email.com", Nivel = NivelAcesso.Nivel1
                    },
                    new Gerente
                    {
                        Id = 2, Nome = "gerente2", Email = "gerente2@email.com", Nivel = NivelAcesso.Nivel2
                    },
                };
                context.Gerentes.AddRange(listaGerentes);

                await context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            var logger = scope.ServiceProvider.GetRequiredService<ILogger>();
            logger.LogError(ex, "An error occurred while migrating the database.");
        }
    }
}