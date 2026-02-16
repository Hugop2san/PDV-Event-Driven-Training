using Microsoft.JSInterop;

namespace PedidosEDA.Infrastructure.Storage;

public sealed class BrowserLocalStorage
{
    private readonly IJSRuntime _js;
    public BrowserLocalStorage(IJSRuntime js) => _js = js;

    public Task SetAsync(string key, string value) =>
        _js.InvokeVoidAsync("localStorage.setItem", key, value).AsTask();

    public Task<string?> GetAsync(string key) =>
        _js.InvokeAsync<string?>("localStorage.getItem", key).AsTask();
}
