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
using Syncfusion.Blazor;


var builder = WebAssemblyHostBuilder.CreateDefault(args);

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mzg0MjIyMEAzMjM5MmUzMDJlMzAzYjMyMzkzYmFDaFE5NkZCZkoraHpObm04endqcFhMS2pHMnUvckE1M3ErbDE5Um9WYlU9");

builder.Services.AddScoped<UserService>();
builder.Services.AddRadzenComponents();
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<TicketService>();


builder.Services.AddMudServices();
builder.Services.AddBlazoredModal();
builder.Services.AddFileReaderService();

//builder.Services.AddScoped<ExportService>();

builder.Services.AddSyncfusionBlazor();





builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
