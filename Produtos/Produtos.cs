namespace ApiCrud.Produtos;

public class Produto
{
    public Guid Id { get; init; }
    public string Nome { get; private set; }
    public bool Ativo { get; private set; }
    public string PathImage { get; set; }
    public decimal Price { get; set; }
    public string BaseDescription { get; set; }
    public string FullDescription { get; set; }
    public Guid CategoryId { get; set; } // Supondo que `CategoryId` é um Guid

    public Produto(string nome)
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
