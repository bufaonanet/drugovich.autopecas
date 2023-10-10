using AutoMapper;
using drugovich.autopecas.application.Contracts.Repositories;
using drugovich.autopecas.application.Exceptions;
using drugovich.autopecas.core;
using MediatR;

namespace drugovich.autopecas.application.Features.Grupos.Queries.GetGrupoById;

public class GetGrupoByIdQueryHandler : IRequestHandler<GetGrupoByIdQuery, GrupoVm>
{
    private readonly IGrupoRepository _grupoRepository;
    private readonly IMapper _mapper;

    public GetGrupoByIdQueryHandler(IGrupoRepository grupoRepository, IMapper mapper)
    {
        _grupoRepository = grupoRepository;
        _mapper = mapper;
    }

    public async Task<GrupoVm> Handle(GetGrupoByIdQuery request, CancellationToken cancellationToken)
    {
        var grupo = await _grupoRepository.GetByIdAsync(request.Id);
        
        if (grupo is null)
        {
            throw new NotFoundException(nameof(Grupo), request.Id);
        }

        var grupoVm = _mapper.Map<GrupoVm>(grupo);
        return grupoVm;
    }
}