using EmagApi.Core.ServiceProvider;
using EmagApi.Core.ServiceProvider.Interface;
using EmargESGIS;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<IProfesseurServices, ProfesseurServices>();
builder.Services.AddScoped<IMatiereServices,MatiereServices>();
builder.Services.AddScoped<IFiliereServices,FiliereServices>();
builder.Services.AddScoped<ISiteServices,SiteServices>();
builder.Services.AddScoped<IEmargementServices,EmargementServices>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7132") });

await builder.Build().RunAsync();
