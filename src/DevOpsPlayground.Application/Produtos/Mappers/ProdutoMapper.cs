using DevOpsPlayground.Application.Produtos.DTOs;
using DevOpsPlayground.Domain.Entities;

namespace DevOpsPlayground.Application.Produtos.Mappers;

public static class ProdutoMapper
{
    public static ProdutoDto ToDto(this Produto produto)
    {
        return new ProdutoDto
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Preco = produto.Preco,
            Estoque = produto.Estoque
        };
    }
}