using EmagApi.Core.Services;
using EmagApi.Core.ServicesProvider;
using EmagApi.Core.ServicesProvider.Interfaces;
using Esgis_Emarg;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7132") });
builder.Services.AddScoped<IProfesseurServices,ProfesseurServices>();
builder.Services.AddScoped<IMatiereServices, MatiereServices>();
builder.Services.AddScoped<IMatiereServices,MatiereServices>();
builder.Services.AddScoped<IFiliereServices,FiliereService>();
builder.Services.AddScoped<ISeanceServices,SeanceServices>();


await builder.Build().RunAsync();
