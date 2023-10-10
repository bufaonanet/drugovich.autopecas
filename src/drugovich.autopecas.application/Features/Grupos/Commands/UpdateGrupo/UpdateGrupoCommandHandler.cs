using AutoMapper;
using drugovich.autopecas.application.Contracts.Repositories;
using drugovich.autopecas.application.Exceptions;
using drugovich.autopecas.core;
using MediatR;

namespace drugovich.autopecas.application.Features.Grupos.Commands.UpdateGrupo;

public class UpdateGrupoCommandHandler : IRequestHandler<UpdateGrupoCommand,Unit>
{
    private readonly IGrupoRepository _grupoRepository;
    private readonly IMapper _mapper;

    public UpdateGrupoCommandHandler(IGrupoRepository grupoRepository, IMapper mapper)
    {
        _grupoRepository = grupoRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateGrupoCommand request, CancellationToken cancellationToken)
    {
        var grupoToUpdate = await _grupoRepository.GetByIdAsync(request.Id);
        if (grupoToUpdate is null)
            throw new NotFoundException(nameof(Grupo), request.Id);

        var validator = new UpdateGrupoCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
            throw new ValidationException(validationResult);
        
        _mapper.Map(request, grupoToUpdate, typeof(UpdateGrupoCommand), typeof(Grupo));

        await _grupoRepository.UpdateAsync(grupoToUpdate);

        return Unit.Value;
    }
}