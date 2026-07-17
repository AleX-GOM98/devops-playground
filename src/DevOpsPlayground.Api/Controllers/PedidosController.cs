using DevOpsPlayground.Application.Pedidos.DTOs;
using DevOpsPlayground.Application.Pedidos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsPlayground.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidosController : ControllerBase
{
    private readonly IPedidoService _pedidoService;

    public PedidosController(IPedidoService pedidoService)
    {
        _pedidoService = pedidoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PedidoDto>>> Get()
    {
        var pedidos = await _pedidoService.GetAllAsync();
        return Ok(pedidos);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<PedidoDto>> Get(Guid id)
    {
        var pedido = await _pedidoService.GetByIdAsync(id);

        if (pedido == null)
            return NotFound();

        return Ok(pedido);
    }

    [HttpPost]
    public async Task<ActionResult<PedidoDto>> Post(CreatePedidoDto dto)
    {
        var pedido = await _pedidoService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(Get),
            new { id = pedido.Id },
            pedido);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<PedidoDto>> Put(Guid id, UpdatePedidoDto dto)
    {
        var pedido = await _pedidoService.UpdateAsync(id, dto);

        if (pedido == null)
            return NotFound();

        return Ok(pedido);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var removido = await _pedidoService.DeleteAsync(id);

        if (!removido)
            return NotFound();

        return NoContent();
    }
}