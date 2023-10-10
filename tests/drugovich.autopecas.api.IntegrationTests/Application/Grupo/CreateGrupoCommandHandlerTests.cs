using drugovich.autopecas.application.Features.Grupos.Commands.CreateGrupo;
using Microsoft.EntityFrameworkCore;

namespace drugovich.autopecas.api.IntegrationTests.Application.Grupo;

public class CreateGrupoCommandHandlerTests : BaseIntegrationsTet
{
    public CreateGrupoCommandHandlerTests(IntegrationTestsWebAppFactory factory) : base(factory)
    {
    }

    [Fact]
    public async Task Create_ShoudeRetunrGrupo_WhenNewCommandIsValid()
    {
        //arrange
        var validCommand = new CreateGrupoCommand { Nome = "Novo Grupo" };

        //act
        var createGrupoCommandResponse = await Sender.Send(validCommand);

        //assert
        Assert.True(createGrupoCommandResponse.Success);
        Assert.NotNull(createGrupoCommandResponse.Grupo);
    }

    [Fact]
    public async Task Create_ShoudeNotReturnGrupo_WhenCommandIsInvalid()
    {
        //arrange
        var invalidCommand = new CreateGrupoCommand { Nome = "" };

        //act
        var createGrupoCommandResponse = await Sender.Send(invalidCommand);

        //assert
        Assert.False(createGrupoCommandResponse.Success);
        Assert.Null(createGrupoCommandResponse.Grupo);
    }

    [Fact]
    public async Task GetByName_ShoudeReturnGrupo_WhenGrupoExistis()
    {
        //arrange
        var novoGrupo = "Novo Grupo";
        var command = new CreateGrupoCommand { Nome = novoGrupo };

        //act
        var createGrupoCommandResponse = await Sender.Send(command);

        var grupo = await DbContext.Grupos.FirstOrDefaultAsync(g => g.Nome == novoGrupo);

        //assert
        Assert.NotNull(grupo);
        Assert.Equal(grupo.Nome, command.Nome);
    }
}