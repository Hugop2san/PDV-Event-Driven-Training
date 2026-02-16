using PedidosEDA.Application.Abstractions;
using PedidosEDA.Domain.Pedidos;
using PedidosEDA.Infrastructure.Bus;

using System.Text.Json;

namespace PedidosEDA.Infrastructure.Storage;



/*
 * Observação honesta: serializar entidade com lista privada pode exigir ajustar o model (expor setter) ou usar DTO interno.
 * Pro portfólio, o jeito mais “limpo” é salvar DTO no storage e reconstruir Pedido (Domain) na leitura. 
 * Se quiser, eu te mando a versão “perfeita DDD”.
 */

public sealed class PedidoRepositoryLocalStorage : IPedidoRepository
{
    private const string Key = "pdv.pedidos.v1";
    private readonly BrowserLocalStorage _ls;

    private static readonly JsonSerializerOptions JsonOpts = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true
    };

    public PedidoRepositoryLocalStorage(BrowserLocalStorage ls) => _ls = ls;

    public async Task<List<Pedido>> GetAllAsync()
    {
        var json = await _ls.GetAsync(Key);
        if (string.IsNullOrWhiteSpace(json)) return new List<Pedido>();
        return JsonSerializer.Deserialize<List<Pedido>>(json, JsonOpts) ?? new List<Pedido>();
    }

    public async Task<Pedido?> GetByIdAsync(Guid id)
        => (await GetAllAsync()).FirstOrDefault(p => p.Id == id);

    public async Task UpsertAsync(Pedido pedido)
    {
        var list = await GetAllAsync();
        var idx = list.FindIndex(p => p.Id == pedido.Id);
        if (idx >= 0) list[idx] = pedido;
        else list.Insert(0, pedido);

        var json = JsonSerializer.Serialize(list, JsonOpts);
        await _ls.SetAsync(Key, json);
    }
}
