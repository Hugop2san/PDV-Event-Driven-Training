using PedidosEDA.Application.Abstractions;
using PedidosEDA.Domain.Pedidos;


namespace PedidosEDA.Application.Pedidos;

public sealed class PedidoService
{
    private readonly IPedidoRepository _repo;
    private readonly IEventBus _bus;

    public PedidoService(IPedidoRepository repo, IEventBus bus)
    {
        _repo = repo;
        _bus = bus;
    }

    public async Task<Guid> CriarPedidoAsync(string cliente, List<(string nome, int qtd, decimal preco)> itens)
    {
        var pedido = new Pedido(cliente);
        foreach (var i in itens)
            pedido.AdicionarItem(i.nome, i.qtd, i.preco);

        await _repo.UpsertAsync(pedido);

        await _bus.PublishAsync(new PedidoCriado(pedido.Id, pedido.Total, pedido.CriadoEm));
        return pedido.Id;
    }

    public async Task CancelarAsync(Guid pedidoId, string motivo)
    {
        var pedido = await _repo.GetByIdAsync(pedidoId);
        if (pedido is null) return;

        pedido.Cancelar(motivo);
        await _repo.UpsertAsync(pedido);

        await _bus.PublishAsync(new PedidoCancelado(pedido.Id, motivo, DateTime.UtcNow));
    }
}
