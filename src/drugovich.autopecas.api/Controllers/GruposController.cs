using System.Net;
using drugovich.autopecas.application.Contracts.Services;
using drugovich.autopecas.application.Features.Grupos.Commands.CreateGrupo;
using drugovich.autopecas.application.Features.Grupos.Commands.DeleteGrupo;
using drugovich.autopecas.application.Features.Grupos.Commands.UpdateGrupo;
using drugovich.autopecas.application.Features.Grupos.Queries.GetGrupoById;
using drugovich.autopecas.application.Features.Grupos.Queries.GetGrupoList;
using drugovich.autopecas.application.InputModels;
using drugovich.autopecas.application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace drugovich.autopecas.api.Controllers;

[Route("api/grupos")]
[ApiController]
//[Authorize]
public class GruposController : ControllerBase
{
    private readonly IGrupoService _grupoService;
    private readonly IMediator _mediator;

    public GruposController(IGrupoService grupoService, IMediator mediator)
    {
        _grupoService = grupoService;
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<GrupoListVm>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAll([FromQuery] string query)
    {
        var getGrupoListQuery = new GetGrupoListQuery() { Query = query };
        var grupos = await _mediator.Send(getGrupoListQuery);
        return Ok(grupos);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(GrupoVm), (int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var getGrupoByIdQuery = new GetGrupoByIdQuery { Id = id };
        var grupo = await _mediator.Send(getGrupoByIdQuery);
        return Ok(grupo);
    }

    [HttpPost(Name = "CreateGrupo")]
    //[Authorize(Roles = "Nivel2")]
    public async Task<ActionResult<CreateGrupoCommandResponse>> Post([FromBody] CreateGrupoCommand createGrupoCommand)
    {
        var response = await _mediator.Send(createGrupoCommand);
        return Ok(response);
    }

    [HttpPut("{id:int}")]
    //[Authorize(Roles = "Nivel2")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateGrupoCommand updateGrupoCommand)
    {
        await _mediator.Send(updateGrupoCommand);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    //[Authorize(Roles = "Nivel2")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> Delete(int id)
    {
        var deleteGrupoCommand = new DeleteGrupoCommand() { Id = id };
        await _mediator.Send(deleteGrupoCommand);
        return NoContent();
    }
}