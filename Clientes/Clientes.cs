namespace ApiCrud.Clientes;

public class Cliente
{
    public Guid Id { get; init; }
    public string Nome {get; private set;}
    public bool Ativo { get; private set; }

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