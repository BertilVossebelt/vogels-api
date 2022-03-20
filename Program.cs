using System.Net.Mime;
using Microsoft.EntityFrameworkCore;
using vogels_api.Data;
using vogels_api.Middleware;
using vogels_api.Services;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var serverVersion = new MariaDbServerVersion(new Version(10, 6, 4));

// Add services to the container.
// Database connection with Pomelo Entity Framework
builder.Services.AddDbContext<AppDbContext>(
    dbContextOptions => dbContextOptions
        .UseMySql(connectionString, serverVersion)
        // The following three options help with debugging, but should
        // be changed or removed for production.
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
);

builder.Services.AddScoped<JwtService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder => {
            builder.WithOrigins("http://localhost:3000")
                .AllowCredentials()
                .AllowAnyMethod()
                .AllowAnyHeader();
        }
    )
);

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthenticationMiddleware();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();