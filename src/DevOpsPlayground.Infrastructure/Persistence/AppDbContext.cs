using DevOpsPlayground.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevOpsPlayground.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Cliente> Clientes => Set<Cliente>();

    public DbSet<Produto> Produtos => Set<Produto>();

    public DbSet<Pedido> Pedidos => Set<Pedido>();
}