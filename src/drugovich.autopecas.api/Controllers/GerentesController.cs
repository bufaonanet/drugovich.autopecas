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
public class GerentesController : ControllerBase
{
    private readonly IGerenteService _gerenteService;

    public GerentesController(IGerenteService gerenteService)
    {
        _gerenteService = gerenteService;
    }

    [HttpGet("listar")]
    [ProducesResponseType(typeof(IEnumerable<GerenteViewModel>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAll()
    {
        var gerentesVm = await _gerenteService.GetAllAsync();
        return Ok(gerentesVm);
    }

    [HttpPost("cadastrar")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Post([FromBody] CreateGerenteInputModel inputModel)
    {
        var gerenteId = await _gerenteService.CreateAsync(inputModel);
        if (gerenteId > 0)
            return Ok("Gerente cadastrado");

        return BadRequest("Falha ao criar gerente");
    }

    [HttpPost("login/{email}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(LoginViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(LoginViewModel), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Put(string email)
    {
        var login = await _gerenteService.LoginAsync(email);
        if (login.Sucesso)
        {
            return Ok(login);
        }
        return BadRequest(login);
    }
}