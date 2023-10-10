using MediatR;

namespace drugovich.autopecas.application.Features.Grupos.Commands.DeleteGrupo;

public class DeleteGrupoCommand : IRequest<Unit>
{
    public int Id { get; set; }
}