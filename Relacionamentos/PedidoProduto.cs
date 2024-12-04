using ApiCrud.Pedidos;
using ApiCrud.Produtos;

namespace ApiCrud.Relacionamentos;
public class PedidoProduto
{
    public Guid ProdutoId { get; set; }
    public Produto Produto { get; set; }

    public Guid PedidoId { get; set; }
    public Pedido Pedido { get; set; }
}