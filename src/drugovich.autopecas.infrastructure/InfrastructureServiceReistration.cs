using System.Text;
using drugovich.autopecas.application.Contracts.Repositories;
using drugovich.autopecas.application.Contracts.Services;
using drugovich.autopecas.infrastructure.Auth;
using drugovich.autopecas.infrastructure.Persistence;
using drugovich.autopecas.infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace drugovich.autopecas.infrastructure;

public static class InfrastructureServiceReistration
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddRepositories()
            .AddPersistence(configuration)
            .AddAuthServices(configuration);
        
        return services;
    }
    
    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        // builder.Services.AddSingleton<DevFreelaDbContextInMemory>();
        // var connectionString = configuration.GetConnectionString("DevFreelaCs");
        // services.AddDbContext<DevFreelaDbContext>(options =>
        // {
        //     var useInMemoryDb = configuration.GetValue<bool>("UseInMemoryDb");
        //
        //     if (useInMemoryDb)
        //         options.UseInMemoryDatabase("DbInMemory");
        //     else
        //         options.UseSqlServer(connectionString);
        // });
        
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseInMemoryDatabase("InMemoryDb");

        });

        return services;
    }
    
    private static IServiceCollection AddRepositories(this IServiceCollection services) {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IGrupoRepository, GrupoRepository>();
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IGerenteRepository, GerenteRepository>();

        return services;
    }
    
    private static IServiceCollection AddAuthServices(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
            });
        
        services.AddScoped<IAuthService, AuthService>();
        
        return services;
    }
}