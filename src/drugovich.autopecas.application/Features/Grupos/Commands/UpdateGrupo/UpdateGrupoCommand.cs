using MediatR;

namespace drugovich.autopecas.application.Features.Grupos.Commands.UpdateGrupo;

public class UpdateGrupoCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nome { get; set; }
}