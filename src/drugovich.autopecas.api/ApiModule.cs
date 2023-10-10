using drugovich.autopecas.core;
using drugovich.autopecas.core.Enums;
using drugovich.autopecas.infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
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

        var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
        if (context == null)
            throw new InvalidOperationException("O contexto do banco de dados não foi registrado.");

        await context.SeedDb();
    }
}