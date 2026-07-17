namespace DevOpsPlayground.Application.Produtos.DTOs;

public class UpdateProdutoDto
{
    public string Nome { get; set; } = string.Empty;

    public decimal Preco { get; set; }

    public int Estoque { get; set; }
}