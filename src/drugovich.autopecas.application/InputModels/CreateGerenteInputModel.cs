using drugovich.autopecas.core.Enums;
using FluentValidation;

namespace drugovich.autopecas.application.InputModels;

public class CreateGerenteInputModel
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public NivelAcesso Nivel { get; set; }
}

public class GerenteInputModelValidation : AbstractValidator<CreateGerenteInputModel>
{
    public GerenteInputModelValidation()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("O nome do gerente não pode ser nulo.")
            .Length(3, 100).WithMessage("Nome dever ter pelo menos 3 caracteres e no máximo 100");
        
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("O email é obrigatório.")
            .EmailAddress().WithMessage("O email não é válido.");
        
        RuleFor(pedido => pedido.Nivel)
            .IsInEnum().WithMessage("Esse não é um nível de acesso válidao");
    }
}