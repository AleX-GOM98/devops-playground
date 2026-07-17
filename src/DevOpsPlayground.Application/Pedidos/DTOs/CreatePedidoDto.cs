namespace DevOpsPlayground.Application.Pedidos.DTOs;

public class CreatePedidoDto
{
    public Guid ClienteId { get; set; }

    public decimal ValorTotal { get; set; }
}