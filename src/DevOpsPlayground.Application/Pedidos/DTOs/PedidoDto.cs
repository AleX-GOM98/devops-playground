namespace DevOpsPlayground.Application.Pedidos.DTOs;

public class PedidoDto
{
    public Guid Id { get; set; }

    public Guid ClienteId { get; set; }

    public DateTime DataPedido { get; set; }

    public decimal ValorTotal { get; set; }
}