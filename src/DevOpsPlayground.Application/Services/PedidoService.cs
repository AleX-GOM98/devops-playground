using DevOpsPlayground.Application.Pedidos.DTOs;
using DevOpsPlayground.Application.Pedidos.Interfaces;
using DevOpsPlayground.Application.Pedidos.Mappers;
using DevOpsPlayground.Domain.Entities;
using DevOpsPlayground.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevOpsPlayground.Application.Pedidos.Services;

public class PedidoService : IPedidoService
{
    private readonly AppDbContext _context;

    public PedidoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PedidoDto>> GetAllAsync()
    {
        return (await _context.Pedidos.ToListAsync())
            .Select(p => p.ToDto());
    }

    public async Task<PedidoDto?> GetByIdAsync(Guid id)
    {
        var pedido = await _context.Pedidos
            .FirstOrDefaultAsync(p => p.Id == id);

        if (pedido == null)
            return null;

        return pedido.ToDto();
    }

    public async Task<PedidoDto> CreateAsync(CreatePedidoDto dto)
    {
        var pedido = new Pedido(dto.ClienteId, dto.ValorTotal);

        _context.Pedidos.Add(pedido);

        await _context.SaveChangesAsync();

        return pedido.ToDto();
    }

    public async Task<PedidoDto?> UpdateAsync(Guid id, UpdatePedidoDto dto)
    {
        var pedido = await _context.Pedidos
            .FirstOrDefaultAsync(p => p.Id == id);

        if (pedido == null)
            return null;

        pedido.AlterarCliente(dto.ClienteId);
        pedido.AlterarDataPedido(dto.DataPedido);
        pedido.AlterarValorTotal(dto.ValorTotal);

        await _context.SaveChangesAsync();

        return pedido.ToDto();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var pedido = await _context.Pedidos
            .FirstOrDefaultAsync(p => p.Id == id);

        if (pedido == null)
            return false;

        _context.Pedidos.Remove(pedido);

        await _context.SaveChangesAsync();

        return true;
    }
}