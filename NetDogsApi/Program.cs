using Microsoft.EntityFrameworkCore;
using NetDogsApi.Configurations;
using NetDogsApi.Dogs;
using NetDogsApi.Shared.Data;
using Sieve.Models;
using Sieve.Services;

var builder = WebApplication.CreateBuilder(args);

// load environment variables from .env file
DotNetEnv.Env.Load();

// read configuration from environment variables
builder.Configuration.AddEnvironmentVariables();

var connectionString = $"Host={Environment.GetEnvironmentVariable("DB_HOST")};" +
                       $"Port={Environment.GetEnvironmentVariable("DB_PORT")};" +
                       $"Database={Environment.GetEnvironmentVariable("DB_NAME")};" +
                       $"Username={Environment.GetEnvironmentVariable("DB_USER")};" +
                       $"Password={Environment.GetEnvironmentVariable("DB_PASSWORD")}";

// Add services to the container
builder.Services.AddOpenApiWithOptions();

builder.Services.AddDbContext<NetDogsApiDbContext>(options =>
    options.UseNpgsql(connectionString
        ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));

builder.Services.AddScoped<NetDogsApiDataSeeder>();

builder.Services.AddScoped<ISieveCustomSortMethods, EmptySieveCustomSortMethods>();
builder.Services.AddScoped<ISieveCustomFilterMethods, EmptySieveCustomFilterMethods>();
builder.Services.AddScoped<ISieveProcessor, ApplicationSieveProcessor>();
builder.Services.Configure<SieveOptions>(builder.Configuration.GetSection("Sieve"));
builder.Services.AddMediatR(cfg => 
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseScalarWithOptions();
}

app.UseHttpsRedirection();

app.MapDogsEndpoints();

await DatabaseInitializer.InitializeAsync(app.Services, app.Configuration);

app.Run();