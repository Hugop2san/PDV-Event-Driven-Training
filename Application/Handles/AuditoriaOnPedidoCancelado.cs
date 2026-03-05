using PedidosEDA.Application.Abstractions;
using PedidosEDA.Domain.Pedidos;
using PedidosEDA.Infrastructure.Events;

public sealed class AuditoriaOnPedidoCancelado : IEventHandler<PedidoCancelado>
{

    private readonly InMemoryEventLog _log;

    public AuditoriaOnPedidoCancelado(InMemoryEventLog log)
    => _log = log;

    public Task HandleAsync(PedidoCancelado e)
    {
        _log.Add($"[CANCELAMENTO] Pedido {e.PedidoId} cancelado.\nMotivo: {e.Motivo}");
        return Task.CompletedTask;
    }
}