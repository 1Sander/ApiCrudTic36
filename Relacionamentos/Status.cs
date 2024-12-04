using ApiCrud.Pedidos;

namespace ApiCrud.Relacionamentos;

public class Status
{
    public int Id { get; set; }
    public string Nome { get; set; }
    
    public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
