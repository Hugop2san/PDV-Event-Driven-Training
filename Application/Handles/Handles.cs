using PedidosEDA.Application.Abstractions;
using PedidosEDA.Domain.Pedidos;
using PedidosEDA.Infrastructure.Events;

namespace Application.Pedidos.Handlers;

public sealed class ReservarEstoqueOnPedidoCriado : IEventHandler<PedidoCriado>
{

    private readonly InMemoryEventLog _log;

    public ReservarEstoqueOnPedidoCriado(InMemoryEventLog log)
        => _log = log;

    public Task HandleAsync(PedidoCriado e)
    {
        // Simula baixa/Reserva de estoque
        _log.Add($"[RESERVA NO ESTOQUE] Reservado para o pedido {e.PedidoId}");
        return Task.CompletedTask;
    }
}

public sealed class NotificarOnPedidoCriado : IEventHandler<PedidoCriado>
{

    private readonly InMemoryEventLog _log;
    
    public NotificarOnPedidoCriado(InMemoryEventLog log)
        => _log = log;
    public Task HandleAsync(PedidoCriado e)
    {
        _log.Add($"[PEDIDO CRIADO] Pedido {e.PedidoId} criado.\nValor Total: ${e.Total}");
        return Task.CompletedTask;
    }
}

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
