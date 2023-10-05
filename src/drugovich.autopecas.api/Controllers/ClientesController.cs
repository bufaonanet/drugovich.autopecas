using System.Net;
using drugovich.autopecas.application.Contracts.Services;
using drugovich.autopecas.application.InputModels;
using drugovich.autopecas.application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace drugovich.autopecas.api.Controllers;

[Route("api/clientes")]
[ApiController]
[Authorize]
public class ClientesController : ControllerBase
{
    private readonly IClienteService _clienteService;

    public ClientesController(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }
    
    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(typeof(IEnumerable<ClienteViewModel>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAll([FromQuery] string query)
    {
        var clienteVm = await _clienteService.GetAllAsync(query);
        return Ok(clienteVm);
    }
    
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(GrupoViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var cliente = await _clienteService.GetByIdAsync(id);
        if (cliente == null)
        {
            return NotFound();
        }

        return Ok(cliente);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(CreateClienteInputModel), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> Post([FromBody] CreateClienteInputModel inputModel)
    {
        var id = await _clienteService.CreateAsync(inputModel);
        return CreatedAtAction(nameof(GetById), new { id }, inputModel);
    }
    
    [HttpPut("{id:int}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateClienteInputModel inputModel)
    {
        if (id != inputModel.Id)
        {
            return BadRequest();
        }

        await _clienteService.UpdateAsync(inputModel);
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> Delete(int id)
    {
        await _clienteService.DeleteAsync(id);
        return NoContent();
    }
}