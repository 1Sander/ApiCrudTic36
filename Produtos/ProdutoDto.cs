namespace ApiCrud.Produtos;

public record ProdutoDto
{
    public Guid Id { get; init; }
    public string Nome { get; init; }
    public bool Ativo { get; init; }
    public string PathImage { get; init; }
    public decimal Price { get; init; }
    public string BaseDescription { get; init; }
    public string FullDescription { get; init; }
    public Guid CategoryId { get; init; }

    public ProdutoDto(Guid id, string nome, bool ativo, string pathImage, decimal price, string baseDescription, string fullDescription, Guid categoryId)
    {
        Id = id;
        Nome = nome;
        Ativo = ativo;
        PathImage = pathImage;
        Price = price;
        BaseDescription = baseDescription;
        FullDescription = fullDescription;
        CategoryId = categoryId;
    }
}
