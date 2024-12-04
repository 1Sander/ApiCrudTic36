namespace ApiCrud.Pedidos;
using ApiCrud.Relacionamentos;

public class Pedido
{
    public Guid Id { get; init; }
    public string Nome { get; private set; }
    public bool Ativo { get; private set; }

    // Relação com ClientePedido
    public ICollection<ClientePedido> ClientePedidos { get; set; } = new List<ClientePedido>();

    // Relação com PedidoProduto
    public ICollection<PedidoProduto> PedidoProdutos { get; set; } = new List<PedidoProduto>();

    public Pedido(string nome)
    {
        Nome = nome;
        Id = Guid.NewGuid();
        Ativo = true;
    }

    public void AtualizarNome(string nome)
    {
        Nome = nome;
    }

    public void Desativar()
    {
        Ativo = false;
    }
}