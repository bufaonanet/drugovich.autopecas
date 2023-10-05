using drugovich.autopecas.core.Common;

namespace drugovich.autopecas.core;

public class Cliente : BaseEntity
{
    public string CNPJ { get; set; }
    public string Nome { get; set; }
    public DateTime DataFundacao { get; set; }

    public int GrupoId { get; set; }
    public Grupo Grupo { get;  set; }
}