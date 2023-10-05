using System.Net;
using drugovich.autopecas.application.Contracts.Services;
using drugovich.autopecas.application.InputModels;
using drugovich.autopecas.application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace drugovich.autopecas.api.Controllers;

[Route("api/grupos")]
[ApiController]
[Authorize]
public class GruposController : ControllerBase
{
    private readonly IGrupoService _grupoService;

    public GruposController(IGrupoService grupoService)
    {
        _grupoService = grupoService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<GrupoViewModel>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAll([FromQuery] string query)
    {
        var gruposVm = await _grupoService.GetAllAsync(query);
        return Ok(gruposVm);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(GrupoViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var grupo = await _grupoService.GetByIdAsync(id);
        if (grupo == null)
        {
            return NotFound();
        }

        return Ok(grupo);
    }

    [HttpPost]
    [Authorize(Roles = "Nivel2")]
    [ProducesResponseType(typeof(CreateGrupoInputModel), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> Post([FromBody] CreateGrupoInputModel inputModel)
    {
        var id = await _grupoService.CreateAsync(inputModel);
        return CreatedAtAction(nameof(GetById), new { id }, inputModel);
    }

    [HttpPut("{id:int}")]
    [Authorize(Roles = "Nivel2")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateGrupoInputModel inputModel)
    {
        if (id != inputModel.Id)
        {
            return BadRequest();
        }

        await _grupoService.UpdateAsync(inputModel);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Nivel2")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> Delete(int id)
    {
        await _grupoService.DeleteAsync(id);
        return NoContent();
    }
}