using ApiCrud.Produtos;
using ApiCrud.Data;
using Microsoft.EntityFrameworkCore;
//using System.Threading;

namespace ApiCrud.Produtos;

public static class ProdutoRotas
{
    public static void AddRotasProdutos(this WebApplication app)
    {
        var rotasProdutos = app.MapGroup("produtos");

        // Cria um novo produto
        rotasProdutos.MapPost(pattern: "",
        handler: async (AddProdutoRequest request, AppDbContext context, CancellationToken ct) =>
        {
            var novoProduto = new Produto(request.Nome);

            await context.Produtos.AddAsync(novoProduto, ct);
            await context.SaveChangesAsync(ct);

            var produtoRetorno = new ProdutoDto(novoProduto.Id, novoProduto.Nome);
            return Results.Ok(produtoRetorno);  
        });

        // Retorna todos os produtos cadastrados
        rotasProdutos.MapGet(pattern: "",
        handler: async (AppDbContext context, CancellationToken ct) => 
        {
            var produtos = await context
                .Produtos
                .Where(produto => produto.Ativo == true)
                .Select(produto => new ProdutoDto(produto.Id, produto.Nome))
                .ToListAsync(ct);
            return Results.Ok(produtos);
        });

        // Atualiza o Nome do Produto
        rotasProdutos.MapPut(pattern: "{id:guid}",
        async (Guid id, UpdateProdutoRequest request, AppDbContext context, CancellationToken ct) =>
        {
            var produto = await context.Produtos
                .SingleOrDefaultAsync(p => p.Id == id, ct);
        
            if (produto == null)
                return Results.NotFound();
        
            produto.AtualizarNome(request.Nome);

            await context.SaveChangesAsync(ct);
            return Results.Ok(new ProdutoDto(produto.Id, produto.Nome));
        });

        // Deleta o Produto
        rotasProdutos.MapDelete(pattern: "{id}",
        async (Guid id, AppDbContext context, CancellationToken ct) =>
        {
            var produto = await context.Produtos
                .SingleOrDefaultAsync(p => p.Id == id, ct);
        
            if (produto == null)
                return Results.NotFound();

            produto.Desativar();

            await context.SaveChangesAsync(ct);
            return Results.Ok();
        });
    }
}
