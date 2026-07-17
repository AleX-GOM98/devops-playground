using DevOpsPlayground.Application.Produtos.DTOs;

namespace DevOpsPlayground.Application.Produtos.Interfaces;

public interface IProdutoService
{
    Task<IEnumerable<ProdutoDto>> GetAllAsync();

    Task<ProdutoDto?> GetByIdAsync(Guid id);

    Task<ProdutoDto> CreateAsync(CreateProdutoDto dto);

    Task<ProdutoDto?> UpdateAsync(Guid id, UpdateProdutoDto dto);

    Task<bool> DeleteAsync(Guid id);
}