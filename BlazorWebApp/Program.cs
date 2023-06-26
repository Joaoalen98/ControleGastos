using Blazored.LocalStorage;
using BlazorWebApp;
using BlazorWebApp.Servico.Api;
using BlazorWebApp.Servico.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp =>
{
    var url = builder.HostEnvironment.IsDevelopment()
        ? "https://localhost:7140"
        : builder.HostEnvironment.BaseAddress;

    var http = new HttpClient { BaseAddress = new Uri(url) };
    return http;
});

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<LocalStorageServico>();

builder.Services.AddScoped<AuthenticationStateProvider, AuthProvider>();
builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<UsuarioApiServico>();
builder.Services.AddScoped<MovimentacaoApiServico>();

await builder.Build().RunAsync();
