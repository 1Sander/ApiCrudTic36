using ApiCrud.Produtos;

namespace ApiCrud.Relacionamentos;

public class Categoria
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string PathImage { get; set; }

    // Propriedade de navegação para os produtos
    public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
