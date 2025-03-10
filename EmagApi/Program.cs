using EmagApi.Application.Services;
using EmagApi.Domain.Interface;
using EmagApi.Infrastructure.DataAccess;
using EmagApi.Infrastructure.Repertory;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System.Text;

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
builder.Services.AddScoped<ISiteRepertory, SiteRepertory>();
builder.Services.AddScoped<ISiteServices, SiteServices>();
builder.Services.AddScoped<IEmargementRepertory, EmargementRepertory>();
builder.Services.AddScoped<IEmargementServices, EmargementServices>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(policy => policy
    .WithOrigins("https://localhost:7274") // Supprimez le chemin
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType)
    .AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();

app.Run();
