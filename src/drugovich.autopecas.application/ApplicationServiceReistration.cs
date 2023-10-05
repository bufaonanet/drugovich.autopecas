using System.Reflection;
using drugovich.autopecas.application.Contracts.Services;
using drugovich.autopecas.application.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace drugovich.autopecas.application;

public static class ApplicationServiceReistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddFluentValidationAutoValidation();
        
        services.AddScoped<IGrupoService, GrupoService>();
        services.AddScoped<IClienteService, ClienteService>();
        services.AddScoped<IGerenteService, GerenteService>();

        return services;
    }
}