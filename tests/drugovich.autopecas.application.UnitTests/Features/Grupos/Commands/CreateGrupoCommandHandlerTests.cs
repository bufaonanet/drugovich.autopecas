using AutoMapper;
using drugovich.autopecas.application.Contracts.Repositories;
using drugovich.autopecas.application.Features.Grupos.Commands.CreateGrupo;
using drugovich.autopecas.application.Mappings;
using drugovich.autopecas.core;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace drugovich.autopecas.application.UnitTests.Features.Grupos.Commands;

public class CreateGrupoCommandHandlerTests
{
    private readonly IGrupoRepository _grupoRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateGrupoCommand> _validator;

    public CreateGrupoCommandHandlerTests()
    {
        _grupoRepository = Substitute.For<IGrupoRepository>();
        _validator = Substitute.For<IValidator<CreateGrupoCommand>>();
        _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()));
        
    }

    [Fact]
    public async Task Handle_WithValidRequest_ReturnsSuccessResponse()
    {
        
        //arrange
        var handler = new CreateGrupoCommandHandler(_grupoRepository, _mapper, _validator);
        
        var request = new CreateGrupoCommand { Nome = "TestGrupo" };
        var grupo = new Grupo { Nome = "TestGrupo" };
        
        _validator.ValidateAsync(request, CancellationToken.None)
            .Returns(new ValidationResult());
        
        _grupoRepository.CreateAsync(Arg.Any<Grupo>()).Returns(grupo);
        
        //_mapper.Map<CreateGrupoDto>(grupo).Returns(new CreateGrupoDto { Nome = "TestGrupo" });
        
        // Act
        var response = await handler.Handle(request, CancellationToken.None);
        
        // Assert
        response.Should().NotBeNull();
        response.Success.Should().BeTrue();
        response.ValidationErrors.Should().BeEmpty();
        response.Grupo.Should().NotBeNull();
        response.Grupo.Nome.Should().Be("TestGrupo");
        
        await _grupoRepository.Received(1).CreateAsync(Arg.Any<Grupo>());
    }
    
    [Fact]
    public async Task Handle_WithInvalidRequest_ReturnsErrorResponse()
    {
        // Arrange

        var handler = new CreateGrupoCommandHandler(_grupoRepository, _mapper, _validator);

        var request = new CreateGrupoCommand(); // Invalid request without a Nome

        var validationErrors = new List<ValidationFailure>
        {
            new ValidationFailure("Nome", "O nome do grupo é obrigatório.")
        };
        
        _validator.ValidateAsync(request, CancellationToken.None)
            .Returns(new ValidationResult(validationErrors));

        // Act
        var response = await handler.Handle(request, CancellationToken.None);

        // Assert
        response.Should().NotBeNull();
        response.Success.Should().BeFalse();
        response.ValidationErrors.Should().NotBeEmpty();
        response.Grupo.Should().BeNull();
        
        await _grupoRepository.DidNotReceive().CreateAsync(Arg.Any<Grupo>());
    }
    
    [Fact]
    public async Task Handle_WithRepositoryException_ReturnsErrorResponse()
    {
        // Arrange
        var handler = new CreateGrupoCommandHandler(_grupoRepository, _mapper, _validator);

        var request = new CreateGrupoCommand { Nome = "TestGrupo" };

        _validator.ValidateAsync(request, CancellationToken.None)
            .Returns(new ValidationResult());

        _grupoRepository
            .CreateAsync(Arg.Any<Grupo>())
            .Throws(new Exception("Simulated repository exception"));

        // Act
        var response = await handler.Handle(request, CancellationToken.None);

        // Assert
        response.Should().NotBeNull();
        response.Success.Should().BeFalse();
        response.ValidationErrors.Should().ContainSingle()
            .And.Subject.Single().Should().Be("Ocorreu um erro ao criar o grupo.");
        response.Grupo.Should().BeNull();
    }

    
}