namespace drugovich.autopecas.application.ViewModels;

public class ClienteViewModel
{
    public int Id { get; set; }
    public string Nome { get;  set; }
    public string CNPJ { get; set; }
    public DateTime DataFundacao { get; set; }
    public int GrupoId { get; set; }
    public string GrupoNome { get;  set; }
}