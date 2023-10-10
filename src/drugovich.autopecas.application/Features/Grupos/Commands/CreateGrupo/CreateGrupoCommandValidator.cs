using FluentValidation;

namespace drugovich.autopecas.application.Features.Grupos.Commands.CreateGrupo;

public class CreateGrupoCommandValidator :AbstractValidator<CreateGrupoCommand> 
{
    public CreateGrupoCommandValidator()
    {
        RuleFor(x => x.Nome)
            .NotNull()
            .NotEmpty().WithMessage("{PropertyName} não pode ser nulo.")
            .Length(3, 100).WithMessage("{PropertyName} dever ter pelo menos 3 caracteres e no máximo 100");
    }
}