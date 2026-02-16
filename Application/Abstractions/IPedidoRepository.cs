using PedidosEDA.Domain.Pedidos;
using PedidosEDA.Domain;

namespace PedidosEDA.Application.Abstractions;

public interface IPedidoRepository
{
    Task<List<Pedido>> GetAllAsync();
    Task<Pedido?> GetByIdAsync(Guid id);
    Task UpsertAsync(Pedido pedido);
}
