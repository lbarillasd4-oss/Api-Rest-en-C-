
using TiendawebAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configuración de Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Conexión con la base de datos MySQL
builder.Services.AddDbContext<TiendaPooContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("coneccion"),
        ServerVersion.AutoDetect(
            builder.Configuration.GetConnectionString("coneccion")
        )
    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
