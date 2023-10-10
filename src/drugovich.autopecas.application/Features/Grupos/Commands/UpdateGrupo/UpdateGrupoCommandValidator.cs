using FluentValidation;

namespace drugovich.autopecas.application.Features.Grupos.Commands.UpdateGrupo;

public class UpdateGrupoCommandValidator : AbstractValidator<UpdateGrupoCommand>
{
    public UpdateGrupoCommandValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("{PropertyName} não pode ser nulo.")
            .Length(3, 100).WithMessage("{PropertyName} deve ter pelo menos 3 caracteres e no máximo 100");
    }
}