using MediatR;

namespace drugovich.autopecas.application.Features.Grupos.Queries.GetGrupoById;

public class GetGrupoByIdQuery : IRequest<GrupoVm>
{
    public int Id { get; set; }
}