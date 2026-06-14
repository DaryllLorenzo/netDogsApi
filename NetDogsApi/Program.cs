using NetDogsApi.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Cargar variables del .env
DotNetEnv.Env.Load();

// Add services to the container
builder.Services.AddOpenApiWithOptions();

// Leer configuración desde variables de entorno
builder.Configuration.AddEnvironmentVariables();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseScalarWithOptions();
}

app.UseHttpsRedirection();

app.Run();