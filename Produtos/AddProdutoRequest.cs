namespace ApiCrud.Produtos;

public record AddProdutoRequest(
    string Nome,
    string PathImage,
    decimal Price,
    string BaseDescription,
    string FullDescription,
    Guid CategoryId
);
