using EmagApi.Application.Services;
using EmagApi.Domain.Interface;
using EmagApi.Infrastructure.DataAccess;
using EmagApi.Infrastructure.Repertory;
using EmagApi.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IProfesseurRepertory, ProfesseurRepertory>();
builder.Services.AddScoped<IProfesseurServices, ProfesseurServices>();
builder.Services.AddScoped<IMatiereRepertory, MatiereRepertory>();
builder.Services.AddScoped<IMatiereServices, MatiereServices>();
builder.Services.AddScoped<IFiliereRepertory,FiliereRepertory>();
builder.Services.AddScoped<IFiliereServices, FiliereServices>();
builder.Services.AddScoped<ISeanceRepertory, SeanceRepertory>();
builder.Services.AddScoped<ISeanceServices, SeanceService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(policy => policy
    .WithOrigins("https://localhost:7051") // Supprimez le chemin
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType)
    .AllowCredentials());


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
