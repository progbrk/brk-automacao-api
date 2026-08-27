using BrkAutomacao.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrkAutomacao.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Produto> Produtos => Set<Produto>();
    public DbSet<Parceiro> Parceiros => Set<Parceiro>();
    public DbSet<Fornecedor> Fornecedores => Set<Fornecedor>();
    public DbSet<Venda> Vendas => Set<Venda>();
    public DbSet<Assinatura> Assinaturas => Set<Assinatura>();
    public DbSet<Compra> Compras => Set<Compra>();
    public DbSet<Comissao> Comissoes => Set<Comissao>();
    public DbSet<Equipamento> Equipamentos => Set<Equipamento>();
    public DbSet<Pagamento> Pagamentos => Set<Pagamento>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
