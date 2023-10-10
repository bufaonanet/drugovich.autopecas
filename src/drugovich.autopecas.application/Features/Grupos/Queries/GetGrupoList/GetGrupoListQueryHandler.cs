using AutoMapper;
using drugovich.autopecas.application.Contracts.Repositories;
using MediatR;

namespace drugovich.autopecas.application.Features.Grupos.Queries.GetGrupoList;

public class GetGrupoListQueryHandler : IRequestHandler<GetGrupoListQuery,List<GrupoListVm>>
{
    private readonly IGrupoRepository _grupoRepository;
    private readonly IMapper _mapper;

    public GetGrupoListQueryHandler(IGrupoRepository grupoRepository, IMapper mapper)
    {
        _grupoRepository = grupoRepository;
        _mapper = mapper;
    }

    public async Task<List<GrupoListVm>> Handle(GetGrupoListQuery request, CancellationToken cancellationToken)
    {
        var grupos = await _grupoRepository.GetAllAsync(request.Query);

        var gruposVm = _mapper.Map<List<GrupoListVm>>(grupos);
        return gruposVm;
    }
}