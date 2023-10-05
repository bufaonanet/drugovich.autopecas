using FluentValidation;

namespace drugovich.autopecas.application.InputModels;

public class CreateGrupoInputModel
{
    public string Nome { get; set; }
}

public class CreateGrupoInputModelValidation : AbstractValidator<CreateGrupoInputModel>
{
    public CreateGrupoInputModelValidation()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("O nome do grupo não pode ser nulo.")
            .Length(3, 100).WithMessage("Nome dever ter pelo menos 3 caracteres e no máximo 100");
    }
}