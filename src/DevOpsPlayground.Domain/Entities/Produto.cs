using DevOpsPlayground.Domain.Common;

namespace DevOpsPlayground.Domain.Entities;

public class Produto : BaseEntity
{
    public string Nome { get; private set; }

    public decimal Preco { get; private set; }

    public int Estoque { get; private set; }

    private Produto()
    {
        Nome = string.Empty;
    }

    public Produto(string nome, decimal preco, int estoque)
    {
        Nome = nome;
        Preco = preco;
        Estoque = estoque;
    }

    public void AlterarNome(string nome)
    {
        Nome = nome;
        MarkAsUpdated();
    }

    public void AtualizarPreco(decimal preco)
    {
        Preco = preco;
        MarkAsUpdated();
    }

    public void AtualizarEstoque(int estoque)
    {
        Estoque = estoque;
        MarkAsUpdated();
    }

    public void AdicionarEstoque(int quantidade)
    {
        Estoque += quantidade;
        MarkAsUpdated();
    }

    public void BaixarEstoque(int quantidade)
    {
        if (quantidade > Estoque)
            throw new InvalidOperationException("Estoque insuficiente.");

        Estoque -= quantidade;
        MarkAsUpdated();
    }
}