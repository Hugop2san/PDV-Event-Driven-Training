using PedidosEDA.Application.Abstractions;
using PedidosEDA.Domain.Pedidos;
using PedidosEDA.Infrastructure.Events;

namespace PedidosEDA.Application.Handles
{
    public class ReservarEstoqueOnPedidoCriado : IEventHandler<PedidoCriado>
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
}
