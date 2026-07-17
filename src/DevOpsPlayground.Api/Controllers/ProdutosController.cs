using DevOpsPlayground.Application.Produtos.DTOs;
using DevOpsPlayground.Application.Produtos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsPlayground.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoService _produtoService;

    public ProdutosController(IProdutoService ProdutoService)
    {
        _produtoService = ProdutoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProdutoDto>>> Get()
    {
        var Produtos = await _produtoService.GetAllAsync();
        return Ok(Produtos);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ProdutoDto>> Get(Guid id)
    {
        var Produto = await _produtoService.GetByIdAsync(id);

        if (Produto == null)
            return NotFound();

        return Ok(Produto);
    }

    [HttpPost]
    public async Task<ActionResult<ProdutoDto>> Post(CreateProdutoDto dto)
    {
        var Produto = await _produtoService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(Get),
            new { id = Produto.Id },
            Produto);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<ProdutoDto>> Put(Guid id, UpdateProdutoDto dto)
    {
        var Produto = await _produtoService.UpdateAsync(id, dto);

        if (Produto == null)
            return NotFound();

        return Ok(Produto);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var removido = await _produtoService.DeleteAsync(id);

        if (!removido)
            return NotFound();

        return NoContent();
    }
}