using DevOpsPlayground.Application.Pedidos.DTOs;

namespace DevOpsPlayground.Application.Pedidos.Interfaces;

public interface IPedidoService
{
    Task<IEnumerable<PedidoDto>> GetAllAsync();

    Task<PedidoDto?> GetByIdAsync(Guid id);

    Task<PedidoDto> CreateAsync(CreatePedidoDto dto);

    Task<PedidoDto?> UpdateAsync(Guid id, UpdatePedidoDto dto);

    Task<bool> DeleteAsync(Guid id);
}