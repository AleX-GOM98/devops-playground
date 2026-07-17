namespace DevOpsPlayground.Application.Pedidos.DTOs;

public class UpdatePedidoDto
{
    public Guid ClienteId { get; set; }

    public DateTime DataPedido { get; set; }

    public decimal ValorTotal { get; set; }
}