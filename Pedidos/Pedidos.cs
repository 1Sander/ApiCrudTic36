namespace ApiCrud.Pedidos;

public class Pedido
{
    public Guid Id { get; init; }
    public string Nome {get; private set;}
    public bool Ativo { get; private set; }

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