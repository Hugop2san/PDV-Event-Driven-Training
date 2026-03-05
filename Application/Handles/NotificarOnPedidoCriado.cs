using PedidosEDA.Application.Abstractions;
using PedidosEDA.Domain.Pedidos;
using PedidosEDA.Infrastructure.Events;

namespace PedidosEDA.Application.Handles
{
    public class NotificarOnPedidoCriado :IEventHandler<PedidoCriado>
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
}
