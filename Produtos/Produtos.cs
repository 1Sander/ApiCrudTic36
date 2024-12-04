namespace ApiCrud.Produtos;
using ApiCrud.Relacionamentos;

public class Produto
{
    public Guid Id { get; init; }
    public string Nome { get; private set; }
    public bool Ativo { get; private set; }
    public string PathImage { get; set; }
    public decimal Price { get; set; }
    public string BaseDescription { get; set; }
    public string FullDescription { get; set; }
    public Guid CategoryId { get; set; }

    // Propriedade de navegação para Categoria
    public Categoria Categoria { get; set; } = null!;

    // Relação com PedidoProduto
    public ICollection<PedidoProduto> PedidoProdutos { get; set; } = new List<PedidoProduto>();

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
