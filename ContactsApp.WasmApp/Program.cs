using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ContactsApp.WasmApp;
using MudBlazor.Services;
using ContactsApp.Shared.ViewModels;
using ContactsApp.Shared.Services;
using ContactsApp.WasmApp.Services;
using ContactsApp.Shared;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5050") });

builder.Services.AddScoped<ContactListViewModel>();
builder.Services.AddTransient<ContactViewModel>();
builder.Services.AddScoped<INavigationService, NavigationService>();
builder.Services.AddScoped<IAlertService, AlertService>();
builder.Services.AddScoped<IApiClient, ApiClient>();

await builder.Build().RunAsync();

