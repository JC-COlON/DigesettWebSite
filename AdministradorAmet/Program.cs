using AdministradorAmet;
using MudBlazor.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using AdministradorAmet.Models;
using Blazored.Modal;
using Tewr.Blazor.FileReader;
using Microsoft.AspNetCore.Http; // Asegúrate de agregar esta línea
using QuestPDF;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped<UserService>();
builder.Services.AddRadzenComponents();
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();

builder.Services.AddMudServices();
builder.Services.AddBlazoredModal();
builder.Services.AddFileReaderService();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
