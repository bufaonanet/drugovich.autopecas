using drugovich.autopecas.api;
using drugovich.autopecas.api.Middleware;
using drugovich.autopecas.application;
using drugovich.autopecas.infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddApiServices()
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddSwaggerConfig();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseHealthChecks("/status");

await app.SeedDatabase();

app.Run();

public partial class Program { }