using ApiCrud.Clientes;
using ApiCrud.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Clientes;

public static class ClientesRotas
{
    public static void AddRotasClientes(this WebApplication app)
    {
        var rotasClientes = app.MapGroup("clientes");

        //cria um novo cliente

        rotasClientes.MapPost(pattern:"",
        handler:async (AddClienteRequest request, AppDbContext context, CancellationToken ct) =>
        {
            var novoCliente = new Cliente(request.Nome);

            await context.Clientes.AddAsync(novoCliente, ct);
            await context.SaveChangesAsync(ct);

            var clienteRetorno = new ClienteDto(novoCliente.Id, novoCliente.Nome);
            return Results.Ok(clienteRetorno);  
        });

        //retorna todos os clientes cadastrados
        rotasClientes.MapGet(pattern:"",
        handler:async(AppDbContext context, CancellationToken ct) => 
        {
            var clientes = await context
            .Clientes
            .Where(cliente => cliente.Ativo == true)
            .Select(cliente => new ClienteDto(cliente.Id, cliente.Nome))
            .ToListAsync(ct);
            return clientes;
        });

        //atualiza Nome Cliente
        rotasClientes.MapPut(pattern:"{id:guid}",
        async(Guid id, UpdateClienteRequest request, AppDbContext context, CancellationToken ct) =>
        {
            var cliente = await context.Clientes
            .SingleOrDefaultAsync(cliente => cliente.Id == id, ct);
        
            if(cliente == null)
                return Results.NotFound();
        
            cliente.AtualizarNome(request.Nome);

            await context.SaveChangesAsync(ct);
            return Results.Ok(new ClienteDto(cliente.Id, cliente.Nome));

        });

        //deleta Cliente
        rotasClientes.MapDelete(pattern:"{id}",
        async(Guid id, AppDbContext context, CancellationToken ct) =>
        {
            var cliente = await context.Clientes
            .SingleOrDefaultAsync(cliente => cliente.Id == id, ct);
        
            if(cliente == null)
                return Results.NotFound();

            cliente.Desativar();

            await context.SaveChangesAsync(ct);
            return Results.Ok();

        });
    
    }
}