using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorApp.Client;
using MudBlazor.Services;
using Blazored.LocalStorage;
using BlazorApp.Client.Services;
using BlazorApp.Shared.Repositories;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddSingleton<FinanceRepository>(s => ActivatorUtilities.CreateInstance<FinanceRepository>(s, "finance.db3"));

builder.Services.AddSingleton<TransactionService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["API_Prefix"] ?? builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();

await builder.Build().RunAsync();
