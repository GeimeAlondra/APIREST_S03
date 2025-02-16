using APIREST_Semana_03.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Agrega el contexto de base de datos y configura la conexión a SQL Server.
builder.Services.AddDbContext<ProductoDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("APIConnection"));
});

// Agrega el soporte para controladores en la API.
builder.Services.AddControllers();

// Habilita la exploración de endpoints para facilitar la documentación.
builder.Services.AddEndpointsApiExplorer();

// Agrega Swagger para generar documentación de la API.
builder.Services.AddSwaggerGen();

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
