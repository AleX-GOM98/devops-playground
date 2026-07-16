namespace DevOpsPlayground.Domain.Entities;

public class Pedido
{
    public Guid Id { get; set; }

    public Guid ClienteId { get; set; }

    public DateTime DataPedido { get; set; } = DateTime.UtcNow;

    public decimal ValorTotal { get; set; }
}