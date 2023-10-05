using System.Net;
using System.Net.Http.Json;
using drugovich.autopecas.api.Controllers;
using drugovich.autopecas.application.Contracts.Services;
using drugovich.autopecas.application.ViewModels;
using Microsoft.AspNetCore.Mvc.Testing;
using NSubstitute;

namespace drugovich.autopecas.api.IntegrationTests.Controllers;

public class ClientesControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public ClientesControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetAll_ReturnsOkResponse()
    {
        // Arrange
        var clienteService = Substitute.For<IClienteService>();
        clienteService.GetAllAsync(Arg.Any<string>()).Returns(new List<ClienteViewModel>());

        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/api/clientes");
        var responseBody = await response.Content.ReadFromJsonAsync<IEnumerable<ClienteViewModel>>();

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(responseBody);
        Assert.IsType<List<ClienteViewModel>>(responseBody);
    }
}