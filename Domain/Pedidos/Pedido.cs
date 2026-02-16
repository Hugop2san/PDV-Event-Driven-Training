using System.Text.Json.Serialization;

namespace PedidosEDA.Domain.Pedidos;

public enum PedidoStatus
{
    Criado = 1,
    Cancelado = 2
}

public sealed class Pedido
{
    [JsonInclude]
    public Guid Id { get; private set; } 
    public DateTime CriadoEm { get; private set; } = DateTime.UtcNow;
    public PedidoStatus Status { get; private set; } = PedidoStatus.Criado;

    [JsonInclude]
    public string ClienteNome { get; private set; } = "";

    [JsonInclude]
    public List<PedidoItem> Itens { get; private set; } = new();

    public decimal Total => Itens.Sum(i => i.Total);

    public Pedido() { } // necessário pro JSON

    public Pedido(string clienteNome)
    {
        Id = Guid.NewGuid();

        if (string.IsNullOrWhiteSpace(clienteNome))
            throw new ArgumentException("Cliente inválido");

        ClienteNome = clienteNome.Trim();
    }

    public void AdicionarItem(string nome, int qtd, decimal preco) =>
        Itens.Add(new PedidoItem(nome, qtd, preco));

    public void Cancelar(string motivo)
    {
        if (Status == PedidoStatus.Cancelado) return;
        Status = PedidoStatus.Cancelado;
    }
}
