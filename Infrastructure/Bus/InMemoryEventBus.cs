//using PedidosEDA.Application.Abstractions.IEventBus;
using Microsoft.Extensions.DependencyInjection;
using PedidosEDA.Application.Abstractions;

namespace PedidosEDA.Infrastructure.Bus;

public sealed class InMemoryEventBus : IEventBus
{
    private readonly IServiceProvider _sp;
    public InMemoryEventBus(IServiceProvider sp) => _sp = sp;

    public async Task PublishAsync<TEvent>(TEvent @event)
    {
        var handlers = _sp.GetServices<IEventHandler<TEvent>>();
        foreach (var h in handlers)
            await h.HandleAsync(@event);
    }
}
