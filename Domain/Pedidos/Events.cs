namespace PedidosEDA.Domain.Pedidos;


public interface IDomainEvent { }

public sealed record PedidoCriado(Guid PedidoId, decimal Total, DateTime CriadoEm) : IDomainEvent;

public sealed record PedidoCancelado(Guid PedidoId, string Motivo, DateTime CanceladoEm) : IDomainEvent;
