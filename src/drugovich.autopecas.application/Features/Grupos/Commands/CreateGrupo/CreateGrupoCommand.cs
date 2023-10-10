using MediatR;

namespace drugovich.autopecas.application.Features.Grupos.Commands.CreateGrupo;

public class CreateGrupoCommand : IRequest<CreateGrupoCommandResponse>
{
    public string Nome { get; set; }
}