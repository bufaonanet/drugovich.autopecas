using AutoMapper;
using drugovich.autopecas.application.Contracts.Repositories;
using drugovich.autopecas.core;
using FluentValidation;
using MediatR;

namespace drugovich.autopecas.application.Features.Grupos.Commands.CreateGrupo;

public class CreateGrupoCommandHandler : IRequestHandler<CreateGrupoCommand, CreateGrupoCommandResponse>
{
    private readonly IGrupoRepository _grupoRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateGrupoCommand> _validator;

    public CreateGrupoCommandHandler(
        IGrupoRepository grupoRepository,
        IMapper mapper,
        IValidator<CreateGrupoCommand> validator)
    {
        _grupoRepository = grupoRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<CreateGrupoCommandResponse> Handle(CreateGrupoCommand request,
        CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return new CreateGrupoCommandResponse()
            {
                Success = false,
                ValidationErrors = validationResult.Errors
                    .Select(error => error.ErrorMessage).ToList()
            };
        }

        try
        {
            var grupo = new Grupo() { Nome = request.Nome };
            grupo = await _grupoRepository.CreateAsync(grupo);

            return new CreateGrupoCommandResponse
            {
                Success = true,
                Grupo = _mapper.Map<CreateGrupoDto>(grupo)
            };
        }
        catch (Exception e)
        {
            // Log the exception if necessary
            return new CreateGrupoCommandResponse
            {
                Success = false,
                ValidationErrors = new List<string> { "Ocorreu um erro ao criar o grupo." }
            };
        }
    }
}