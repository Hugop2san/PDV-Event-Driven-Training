//using PedidosEDA.Domain.Pedidos.PedidoItem;

namespace PedidosEDA.Domain.Pedidos;
public enum PedidoStatus
{
    Criado = 1,
    Cancelado = 2
}

public sealed class Pedido
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public DateTime CriadoEm { get; private set; } = DateTime.UtcNow;
    public PedidoStatus Status { get; private set; } = PedidoStatus.Criado;

    public string ClienteNome { get; private set; }
    private readonly List<PedidoItem> _itens = new();
    public IReadOnlyList<PedidoItem> Itens => _itens;

    public decimal Total => _itens.Sum(i => i.Total);

    public Pedido(string clienteNome)
    {
        if (string.IsNullOrWhiteSpace(clienteNome)) throw new ArgumentException("Cliente inválido");
        ClienteNome = clienteNome.Trim();
    }

    public void AdicionarItem(string nome, int qtd, decimal preco) =>
        _itens.Add(new PedidoItem(nome, qtd, preco));

    public void Cancelar(string motivo)
    {
        if (Status == PedidoStatus.Cancelado) return;
        Status = PedidoStatus.Cancelado;
        // motivo entra melhor em um evento (ex: PedidoCancelado)
    }
}
