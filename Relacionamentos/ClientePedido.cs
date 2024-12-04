using ApiCrud.Clientes;
using ApiCrud.Pedidos;

namespace ApiCrud.Relacionamentos;

public class ClientePedido
{
    public Guid ClienteId { get; set; } // Altere de int para Guid
    public Cliente Cliente { get; set; }
    
    public Guid PedidoId { get; set; }
    public Pedido Pedido { get; set; }
}
