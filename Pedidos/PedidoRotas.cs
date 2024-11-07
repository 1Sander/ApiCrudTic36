using ApiCrud.Pedidos;
using ApiCrud.Data;
using Microsoft.EntityFrameworkCore;
//using System.Threading;

namespace ApiCrud.Pedidos;

public static class PedidoRotas
{
    public static void AddRotasPedidos(this WebApplication app)
    {
        var rotasPedidos = app.MapGroup("pedidos");

        // Cria um novo pedido
        rotasPedidos.MapPost(pattern: "",
        handler: async (AddPedidoRequest request, AppDbContext context, CancellationToken ct) =>
        {
            var novoPedido = new Pedido(request.Nome);

            await context.Pedidos.AddAsync(novoPedido, ct);
            await context.SaveChangesAsync(ct);

            var pedidoRetorno = new PedidoDto(novoPedido.Id, novoPedido.Nome);
            return Results.Ok(pedidoRetorno);  
        });

        // Retorna todos os pedidos cadastrados
        rotasPedidos.MapGet(pattern: "",
        handler: async (AppDbContext context, CancellationToken ct) => 
        {
            var pedidos = await context
                .Pedidos
                .Where(pedido => pedido.Ativo == true)
                .Select(pedido => new PedidoDto(pedido.Id, pedido.Nome))
                .ToListAsync(ct);
            return Results.Ok(pedidos);
        });

        // Atualiza o Nome do Pedido
        rotasPedidos.MapPut(pattern: "{id:guid}",
        async (Guid id, UpdatePedidoRequest request, AppDbContext context, CancellationToken ct) =>
        {
            var pedido = await context.Pedidos
                .SingleOrDefaultAsync(p => p.Id == id, ct);
        
            if (pedido == null)
                return Results.NotFound();
        
            pedido.AtualizarNome(request.Nome);

            await context.SaveChangesAsync(ct);
            return Results.Ok(new PedidoDto(pedido.Id, pedido.Nome));
        });

        // Deleta o Pedido
        rotasPedidos.MapDelete(pattern: "{id}",
        async (Guid id, AppDbContext context, CancellationToken ct) =>
        {
            var pedido = await context.Pedidos
                .SingleOrDefaultAsync(p => p.Id == id, ct);
        
            if (pedido == null)
                return Results.NotFound();

            pedido.Desativar();

            await context.SaveChangesAsync(ct);
            return Results.Ok();
        });
    }
}
