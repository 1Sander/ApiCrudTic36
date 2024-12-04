using ApiCrud.Relacionamentos;

namespace ApiCrud.Clientes;

public class Cliente
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public bool Ativo { get; set; }

    // Propriedade de navegação para os relacionamentos com pedidos
    public ICollection<ClientePedido> ClientePedidos { get; set; } = new List<ClientePedido>();

    public Cliente(string nome)
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
