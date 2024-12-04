using ApiCrud.Clientes;
using ApiCrud.Pedidos;
using ApiCrud.Produtos;
using Microsoft.EntityFrameworkCore;
using ApiCrud.Relacionamentos;

namespace ApiCrud.Data;

public class AppDbContext : DbContext
{
    public required DbSet<Categoria> Categorias { get; set; }
    public required DbSet<Status> Status { get; set; }
    public required DbSet<ClientePedido> ClientePedidos { get; set; }
    public required DbSet<PedidoProduto> PedidoProdutos { get; set; }
    public required DbSet<Cliente> Clientes { get; set; }
    public required DbSet<Pedido> Pedidos { get; set; }
    public required DbSet<Produto> Produtos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(connectionString: "Data Source=Banco.sqlite");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuração para ClientePedido
        modelBuilder.Entity<ClientePedido>()
            .HasKey(cp => new { cp.ClienteId, cp.PedidoId });

        modelBuilder.Entity<ClientePedido>()
            .HasOne(cp => cp.Cliente)
            .WithMany(c => c.ClientePedidos)
            .HasForeignKey(cp => cp.ClienteId);

        modelBuilder.Entity<ClientePedido>()
            .HasOne(cp => cp.Pedido)
            .WithMany(p => p.ClientePedidos)
            .HasForeignKey(cp => cp.PedidoId);

        // Configuração para PedidoProduto
        modelBuilder.Entity<PedidoProduto>()
            .HasKey(pp => new { pp.PedidoId, pp.ProdutoId });

        modelBuilder.Entity<PedidoProduto>()
            .HasOne(pp => pp.Pedido)
            .WithMany(p => p.PedidoProdutos)
            .HasForeignKey(pp => pp.PedidoId);

        modelBuilder.Entity<PedidoProduto>()
            .HasOne(pp => pp.Produto)
            .WithMany(p => p.PedidoProdutos)
            .HasForeignKey(pp => pp.ProdutoId);

        // Configuração para Produto e Categoria
        modelBuilder.Entity<Produto>()
            .HasOne(p => p.Categoria)
            .WithMany(c => c.Produtos)
            .HasForeignKey(p => p.CategoryId);

        base.OnModelCreating(modelBuilder);
    }
}
