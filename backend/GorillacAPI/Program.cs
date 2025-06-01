using GorillacApi;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

// Load .env file if present (for all environments)
Env.Load();

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

// Always check environment variables for DB credentials, fallback to config files
string? envConnStr = Environment.GetEnvironmentVariable("DefaultConnection");
string? envUserId = Environment.GetEnvironmentVariable("UserId");
string? envPassword = Environment.GetEnvironmentVariable("Password");

string configConnStr = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
var configSection = builder.Configuration.GetSection("ConnectionStrings");
string configUserId = configSection["UserId"] ?? string.Empty;
string configPassword = configSection["Password"] ?? string.Empty;

string baseConnStr = !string.IsNullOrWhiteSpace(envConnStr) ? envConnStr : configConnStr;
string userId = !string.IsNullOrWhiteSpace(envUserId) ? envUserId : configUserId;
string password = !string.IsNullOrWhiteSpace(envPassword) ? envPassword : configPassword;

if (string.IsNullOrWhiteSpace(baseConnStr) || string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(password))
{
    Console.WriteLine("[DB CONFIG ERROR] Connection string, UserId, or Password is missing in environment variables and configuration.");
}
else
{
    string finalConnStr = baseConnStr.Replace("{UserId}", userId).Replace("{Password}", password);
    // Register DbContext with the composed connection string
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(finalConnStr));

    // Test database connection at startup
    try
    {
        using var conn = new SqlConnection(finalConnStr);
        conn.Open();
        Console.WriteLine($"[DB TEST] Successfully connected to: {conn.Database} on {conn.DataSource}");
        conn.Close();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"[DB TEST ERROR] {ex.Message}");
    }
}

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

app.Run();
