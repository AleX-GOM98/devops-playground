using DevOpsPlayground.Application.Clientes.DTOs;
using DevOpsPlayground.Application.Clientes.Interfaces;
using DevOpsPlayground.Application.Clientes.Mappers;
using DevOpsPlayground.Domain.Entities;
using DevOpsPlayground.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace DevOpsPlayground.Application.Clientes.Services;

public class ClienteService : IClienteService
{
    private readonly AppDbContext _context;

    public ClienteService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ClienteDto>> GetAllAsync()
    {
        return (await _context.Clientes.ToListAsync())
                .Select(c => c.ToDto());
    }

    public async Task<ClienteDto?> GetByIdAsync(Guid id)
    {
        var cliente = await _context.Clientes
            .FirstOrDefaultAsync(c => c.Id == id);

        if (cliente == null)
            return null;

        return cliente?.ToDto();
    }

    public async Task<ClienteDto> CreateAsync(CreateClienteDto dto)
    {
        var cliente = new Cliente(dto.Nome, dto.Email);

        _context.Clientes.Add(cliente);

        await _context.SaveChangesAsync();

        return cliente.ToDto();
    }

    public async Task<ClienteDto?> UpdateAsync(Guid id, UpdateClienteDto dto)
    {
        var cliente = await _context.Clientes
            .FirstOrDefaultAsync(c => c.Id == id);

        if (cliente == null)
            return null;

        cliente.AlterarNome(dto.Nome);
        cliente.AlterarEmail(dto.Email);

        await _context.SaveChangesAsync();

        return cliente.ToDto();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var cliente = await _context.Clientes
            .FirstOrDefaultAsync(c => c.Id == id);

        if (cliente == null)
            return false;

        _context.Clientes.Remove(cliente);

        await _context.SaveChangesAsync();

        return true;
    }
}