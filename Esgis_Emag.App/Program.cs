using EmagApi.Core.ServicesProvider;
using EmagApi.Core.ServicesProvider.Interfaces;
using Esgis_Emag.App;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7132") });
builder.Services.AddScoped<IProfesseurServices, EmagApi.Core.ServicesProvider.ProfesseurServices>();
builder.Services.AddScoped<IMatiereServices, MatiereServices>();
await builder.Build().RunAsync();
