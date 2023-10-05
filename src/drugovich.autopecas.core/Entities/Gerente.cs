using drugovich.autopecas.core.Common;
using drugovich.autopecas.core.Enums;

namespace drugovich.autopecas.core;

public class Gerente : BaseEntity
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public NivelAcesso Nivel { get; set; }
}