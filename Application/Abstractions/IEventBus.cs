

namespace PedidosEDA.Application.Abstractions;

public interface IEventBus
{
    Task PublishAsync<TEvent>(TEvent @event);
}
