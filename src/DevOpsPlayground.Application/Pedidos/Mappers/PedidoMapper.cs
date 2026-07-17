using DevOpsPlayground.Application.Pedidos.DTOs;
using DevOpsPlayground.Domain.Entities;

namespace DevOpsPlayground.Application.Pedidos.Mappers;

public static class PedidoMapper
{
    public static PedidoDto ToDto(this Pedido pedido)
    {
        return new PedidoDto
        {
            Id = pedido.Id,
            ClienteId = pedido.ClienteId,
            DataPedido = pedido.DataPedido,
            ValorTotal = pedido.ValorTotal
        };
    }
}