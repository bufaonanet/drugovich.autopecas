using FluentValidation;

namespace drugovich.autopecas.application.InputModels;

public class UpdateGrupoInputModel
{
    public int Id { get; set; }
    public string Nome { get;  set; }
}

public class UpdateGrupoInputModelValidation : AbstractValidator<UpdateGrupoInputModel>
{
    public UpdateGrupoInputModelValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("O Id do grupo não pode ser nulo.");
        
        RuleFor(x => x.Nome)
            .NotEmpty()
            .Length(3, 100).WithMessage("Full Name dever ter pelo menos 3 caracteres e no máximo 100");
    }
}