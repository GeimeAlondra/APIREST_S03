using APIREST_Semana_03.Models;
using Microsoft.EntityFrameworkCore;

namespace APIREST_Semana_03.Context
{
    // Contexto de base de datos para gestionar los productos.
    public class ProductoDbContext : DbContext
    {
        // Constructor que recibe las opciones de configuración de la base de datos.
        public ProductoDbContext(DbContextOptions<ProductoDbContext> options) : base(options) { }

        // Tabla de productos en la base de datos.
        public DbSet<Producto> Productos { get; set; }
    }
}
