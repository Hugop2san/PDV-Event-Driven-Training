namespace PedidosEDA.Infrastructure.Events;

public sealed class InMemoryEventLog
{
    private readonly List<string> _events = new();

    // adicionando evento para atualizar UI apos uma ação
    public event Action? OnChange;

    public void Add(string message)
    {
        _events.Insert(0, message);
        if (_events.Count > 20)
            _events.RemoveAt(_events.Count - 1);

        OnChange?.Invoke(); //avisa que mudou
    }

    public IReadOnlyList<string> GetAll() => _events;
}

