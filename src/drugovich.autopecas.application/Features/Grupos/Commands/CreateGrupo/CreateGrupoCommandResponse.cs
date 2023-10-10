using drugovich.autopecas.application.Responses;

namespace drugovich.autopecas.application.Features.Grupos.Commands.CreateGrupo;

public class CreateGrupoCommandResponse : BaseResponse
{
    public CreateGrupoDto Grupo { get; set; }
}