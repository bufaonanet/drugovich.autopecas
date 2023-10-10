using AutoMapper;
using drugovich.autopecas.application.Contracts.Repositories;
using drugovich.autopecas.application.Exceptions;
using drugovich.autopecas.core;
using MediatR;

namespace drugovich.autopecas.application.Features.Grupos.Commands.DeleteGrupo;

public class DeleteGrupoCommandHandler : IRequestHandler<DeleteGrupoCommand, Unit>
{
    private readonly IGrupoRepository _grupoRepository;
    private readonly IMapper _mapper;

    public DeleteGrupoCommandHandler(IGrupoRepository grupoRepository, IMapper mapper)
    {
        _grupoRepository = grupoRepository;
        _mapper = mapper;
    }


    public async Task<Unit> Handle(DeleteGrupoCommand request, CancellationToken cancellationToken)
    {
        var grupoToDelete = await _grupoRepository.GetByIdAsync(request.Id);
        if (grupoToDelete is null)
            throw new NotFoundException(nameof(Grupo), request.Id);

        await _grupoRepository.DeleteAsync(grupoToDelete);
        
        return Unit.Value;
    }
}