namespace PedidosEDA.Domain.Pedidos;

public sealed class PedidoItem
{
    public string Nome { get; }
    public int Quantidade { get; }
    public decimal PrecoUnitario { get; }

    public PedidoItem(string nome, int quantidade, decimal precoUnitario)
    {
        if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException("Nome inválido");
        if (quantidade <= 0) throw new ArgumentException("Quantidade inválida");
        if (precoUnitario <= 0) throw new ArgumentException("Preço inválido");

        Nome = nome;
        Quantidade = quantidade;
        PrecoUnitario = precoUnitario;
    }

    public decimal Total => Quantidade * PrecoUnitario;
}