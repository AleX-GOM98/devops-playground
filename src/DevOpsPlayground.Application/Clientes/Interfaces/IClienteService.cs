using DevOpsPlayground.Application.Clientes.DTOs;

namespace DevOpsPlayground.Application.Clientes.Interfaces;

public interface IClienteService
{
    Task<IEnumerable<ClienteDto>> GetAllAsync();

    Task<ClienteDto?> GetByIdAsync(Guid id);

    Task<ClienteDto> CreateAsync(CreateClienteDto dto);

    Task<ClienteDto?> UpdateAsync(Guid id, UpdateClienteDto dto);

    Task<bool> DeleteAsync(Guid id);
}