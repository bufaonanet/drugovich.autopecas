using FluentValidation;

namespace drugovich.autopecas.application.InputModels;

public class UpdateClienteInputModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int GrupoId { get; set; }
}

public class UpdateClienteInputModelValidation : AbstractValidator<UpdateClienteInputModel>
{
    public UpdateClienteInputModelValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("O Id do Cliente não pode ser nulo.");
        
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("O nome do Cliente não pode ser nulo.")
            .Length(3, 100).WithMessage("Nome dever ter pelo menos 3 caracteres e no máximo 100");

        RuleFor(x => x.GrupoId)
            .NotEmpty().WithMessage("O Id do grupo não pode ser nulo.");
    }
}