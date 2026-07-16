using DevOpsPlayground.Domain.Common;

namespace DevOpsPlayground.Domain.Entities;

public class Pedido : BaseEntity
{
    public Guid ClienteId { get; private set; }

    public DateTime DataPedido { get; private set; }

    public decimal ValorTotal { get; private set; }

    private Pedido()
    {
    }

    public Pedido(Guid clienteId, decimal valorTotal)
    {
        ClienteId = clienteId;
        ValorTotal = valorTotal;
        DataPedido = DateTime.UtcNow;
    }
}