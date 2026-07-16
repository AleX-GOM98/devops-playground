using DevOpsPlayground.Application.Clientes.DTOs;
using DevOpsPlayground.Domain.Entities;

namespace DevOpsPlayground.Application.Clientes.Mappers;

public static class ClienteMapper
{
    public static ClienteDto ToDto(this Cliente cliente)
    {
        return new ClienteDto
        {
            Id = cliente.Id,
            Nome = cliente.Nome,
            Email = cliente.Email
        };
    }
}