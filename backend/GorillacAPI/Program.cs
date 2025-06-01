using GorillacApi;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

// Load .env file if present (for all environments)
Env.Load("/var/www/gorillac/backend/GorillacAPI/published/.env");

// Only load secrets from appsettings.Secrets.json in Development
if (builder.Environment.IsDevelopment())
{
    // Load secrets from appsettings.Secrets.json (not tracked by git)
    builder.Configuration.AddJsonFile("appsettings.Secrets.json", optional: true, reloadOnChange: true);
}

// Helper: Get config value from environment variable or config file
string GetConfig(string key, string? section = null)
{
    var env = Environment.GetEnvironmentVariable(key);
    if (!string.IsNullOrWhiteSpace(env)) return env;
    if (section != null)
        return builder.Configuration.GetSection(section)[key] ?? string.Empty;
    return builder.Configuration[key] ?? string.Empty;
}

// Use connection string from environment variable
var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__Default");

if (string.IsNullOrEmpty(connectionString))
{
    Console.WriteLine("[DB CONFIG ERROR] Connection string is missing from environment.");
}
else
{
    Console.WriteLine("[DB CONFIG] Loaded connection string from environment.");
}

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();

// Add Swagger/OpenAPI support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GorillacAPI", Version = "v1" });
});

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Enable CORS for all requests
app.UseCors();

// Enable Swagger middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "GorillacAPI v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Listen on all interfaces for port 5000
app.Urls.Add("http://0.0.0.0:5000");

app.Run();
