using MediatR;

namespace drugovich.autopecas.application.Features.Grupos.Queries.GetGrupoList;

public class GetGrupoListQuery : IRequest<List<GrupoListVm>>
{
    public string Query { get; set; } 
  
}