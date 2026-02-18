using Application.Pedidos.Handlers;
using PedidosEDA.Application.Abstractions;
using PedidosEDA.Application.Pedidos;
using PedidosEDA.Components;
using PedidosEDA.Domain.Pedidos;
using PedidosEDA.Infrastructure.Bus;
using PedidosEDA.Infrastructure.Events;
using PedidosEDA.Infrastructure.Storage;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//DI do backend do projeto
builder.Services.AddScoped<BrowserLocalStorage>();

builder.Services.AddScoped<IPedidoRepository, PedidoRepositoryLocalStorage>();

builder.Services.AddScoped<IEventBus, InMemoryEventBus>();

builder.Services.AddScoped<PedidoService>();

builder.Services.AddSingleton<InMemoryEventLog>();

// ADCIIONAR CONTEUDO NO APPLICATION/HANDLES/HANDLES.CS
builder.Services.AddScoped<IEventHandler<PedidoCriado>, ReservarEstoqueOnPedidoCriado>();
builder.Services.AddScoped<IEventHandler<PedidoCriado>, NotificarOnPedidoCriado>();
builder.Services.AddScoped<IEventHandler<PedidoCancelado>, AuditoriaOnPedidoCancelado>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
