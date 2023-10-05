using FluentValidation;

namespace drugovich.autopecas.application.InputModels;

public class CreateClienteInputModel
{
    public string CNPJ { get; set; }
    public string Nome { get; set; }
    public DateTime DataFundacao { get; set; }

    public int GrupoId { get; set; }
}

public class CreateClienteInputModelValidation : AbstractValidator<CreateClienteInputModel>
{
    public CreateClienteInputModelValidation()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("O nome do Cliente não pode ser nulo.")
            .Length(3, 100).WithMessage("Nome dever ter pelo menos 3 caracteres e no máximo 100");
        
        RuleFor(c => c.DataFundacao)
            .Must(BeMenorOuIgualADataAtual)
            .WithMessage("Data da Fundação deve ser anterior a hoje");
        
        RuleFor(cliente => cliente.CNPJ)
            .NotEmpty().WithMessage("O CNPJ é obrigatório.")
            .Length(14).WithMessage("O CNPJ deve ter 14 dígitos.")
            .Matches(@"^\d{14}$").WithMessage("O CNPJ deve conter apenas dígitos numéricos.");
        
        RuleFor(x => x.GrupoId)
            .NotEmpty().WithMessage("O Id do grupo não pode ser nulo.");
    }
    
    private bool BeMenorOuIgualADataAtual(DateTime data)
    {
        return data <= DateTime.Now;
    }
}