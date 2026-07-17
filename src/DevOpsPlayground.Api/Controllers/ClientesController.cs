using DevOpsPlayground.Application.Clientes.DTOs;
using DevOpsPlayground.Application.Clientes.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsPlayground.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly IClienteService _clienteService;

    public ClientesController(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClienteDto>>> Get()
    {
        var clientes = await _clienteService.GetAllAsync();
        return Ok(clientes);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ClienteDto>> Get(Guid id)
    {
        var cliente = await _clienteService.GetByIdAsync(id);

        if (cliente == null)
            return NotFound();

        return Ok(cliente);
    }

    [HttpPost]
    public async Task<ActionResult<ClienteDto>> Post(CreateClienteDto dto)
    {
        var cliente = await _clienteService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(Get),
            new { id = cliente.Id },
            cliente);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<ClienteDto>> Put(Guid id, UpdateClienteDto dto)
    {
        var cliente = await _clienteService.UpdateAsync(id, dto);

        if (cliente == null)
            return NotFound();

        return Ok(cliente);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var removido = await _clienteService.DeleteAsync(id);

        if (!removido)
            return NotFound();

        return NoContent();
    }
}