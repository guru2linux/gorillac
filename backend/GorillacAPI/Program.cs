using GorillacApi;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Load secrets from appsettings.Secrets.json (not tracked by git)
builder.Configuration.AddJsonFile("appsettings.Secrets.json", optional: true, reloadOnChange: true);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

// Test database connection at startup
try
{
    var secrets = builder.Configuration.GetSection("ConnectionStrings");
    var userId = secrets["UserId"];
    var password = secrets["Password"];
    var baseConnStr = builder.Configuration.GetConnectionString("DefaultConnection");
    if (string.IsNullOrWhiteSpace(baseConnStr) || string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(password))
    {
        Console.WriteLine("[DB TEST ERROR] Connection string, UserId, or Password is missing in configuration.");
    }
    else
    {
        var connStr = baseConnStr.Replace("{UserId}", userId).Replace("{Password}", password);
        using var conn = new SqlConnection(connStr);
        conn.Open();
        Console.WriteLine($"[DB TEST] Successfully connected to: {conn.Database} on {conn.DataSource}");
        conn.Close();
    }
}
catch (Exception ex)
{
    Console.WriteLine($"[DB TEST ERROR] {ex.Message}");
}

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
