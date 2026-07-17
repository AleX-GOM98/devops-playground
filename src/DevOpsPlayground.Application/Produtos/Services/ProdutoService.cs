using DevOpsPlayground.Application.Produtos.DTOs;
using DevOpsPlayground.Application.Produtos.Interfaces;
using DevOpsPlayground.Application.Produtos.Mappers;
using DevOpsPlayground.Domain.Entities;
using DevOpsPlayground.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevOpsPlayground.Application.Produtos.Services;

public class ProdutoService : IProdutoService
{
    private readonly AppDbContext _context;

    public ProdutoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProdutoDto>> GetAllAsync()
    {
        return (await _context.Produtos.ToListAsync())
            .Select(p => p.ToDto());
    }

    public async Task<ProdutoDto?> GetByIdAsync(Guid id)
    {
        var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);

        if (produto == null)
            return null;

        return produto.ToDto();
    }

    public async Task<ProdutoDto> CreateAsync(CreateProdutoDto dto)
    {
        var produto = new Produto(dto.Nome, dto.Preco, dto.Estoque);

        _context.Produtos.Add(produto);

        await _context.SaveChangesAsync();

        return produto.ToDto();
    }

    public async Task<ProdutoDto?> UpdateAsync(Guid id, UpdateProdutoDto dto)
    {
        var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);

        if (produto == null)
            return null;

        produto.AlterarNome(dto.Nome);
        produto.AtualizarPreco(dto.Preco);
        produto.AtualizarEstoque(dto.Estoque);

        await _context.SaveChangesAsync();

        return produto.ToDto();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);

        if (produto == null)
            return false;

        _context.Produtos.Remove(produto);

        await _context.SaveChangesAsync();

        return true;
    }
}