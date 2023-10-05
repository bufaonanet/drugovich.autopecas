using AutoMapper;
using drugovich.autopecas.application.Contracts.Repositories;
using drugovich.autopecas.application.Exceptions;
using drugovich.autopecas.application.Mappings;
using drugovich.autopecas.application.Services;
using drugovich.autopecas.application.ViewModels;
using drugovich.autopecas.core;
using NSubstitute;

namespace drugovich.autopecas.application.UnitTests;

public class ClienteServiceTests
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IGrupoRepository _grupoRepository;
    private readonly IMapper _mapper;

    public ClienteServiceTests()
    {
        _clienteRepository = Substitute.For<IClienteRepository>();
        _grupoRepository = Substitute.For<IGrupoRepository>();
        _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()));
    }

    [Fact]
    public async Task GetAllAsync_Should_Return_ClienteViewModelList()
    {
        // Arrange

        var clienteService = new ClienteService(_clienteRepository, _grupoRepository, _mapper);

        var query = string.Empty;
        var clientesFromRepo = new List<Cliente>();
        _clienteRepository.GetAllClientesWithGruposAsync(query).Returns(clientesFromRepo);

        // Act
        var result = await clienteService.GetAllAsync(query);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<List<ClienteViewModel>>(result);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnClienteViewModel_WhenValidIdProvided()
    {
        // Arrange
        int clientId = 1;

        var clienteService = new ClienteService(_clienteRepository, _grupoRepository, _mapper);

        var clienteFromRepo = new Cliente { Id = clientId };

        _clienteRepository.GetClienteByIdWIthGrupoAsync(clientId).Returns(clienteFromRepo);

        // Act
        var result = await clienteService.GetByIdAsync(clientId);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<ClienteViewModel>(result);
        Assert.Equal(clientId, result.Id);
    }

    [Fact]
    public async Task CheckIfGroupExists_ShouldThrowNotFoundException_WhenGroupDoesNotExist()
    {
        // Arrange
        int groupId = 1;
        _grupoRepository.GetByIdAsync(groupId).Returns((Grupo)null);

        var clienteService = new ClienteService(_clienteRepository, _grupoRepository, _mapper);
        
        // Act & Assert
        await Assert.ThrowsAsync<NotFoundException>(async () => await clienteService.CheckIfGroupExists(groupId));
    }
}