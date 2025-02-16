using APIREST_Semana_03.Context;
using APIREST_Semana_03.DTOs;
using APIREST_Semana_03.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIREST_Semana_03.Controllers
{
    // Define la ruta base de este controlador como "api/producto".
    [Route("api/productos")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        // Contexto de base de datos para acceder a los productos.
        private ProductoDbContext _context;

        // Constructor que recibe el contexto de base de datos.
        public ProductoController(ProductoDbContext context)
        {
            _context = context;
        }

        // Método para obtener todos los productos.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDTO>>> ObtenerProducto()
        {
            // Obtiene la lista de productos desde la base de datos.
            var productos = await _context.Productos.ToListAsync();

            // Devuelve un error si no hay productos en la base de datos
            if (productos == null || productos.Count == 0)
            {
                return NotFound(new { mensaje = "No se encontraron productos." });
            }

            // Convierte la lista a DTOs para devolver solo los datos necesarios.
            var productosDTO = productos.Select(p => new ProductoDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.Precio,
                Stock = p.Stock
            }).ToList();

            return Ok(new { mensaje = "Productos obtenidos con éxito.", productos = productosDTO });
        }

        // Método para obtener un producto por su id.
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDTO>> ObtenerProductoPorId(int id)
        {
            // Busca el producto en la base de datos.
            var producto = await _context.Productos.FindAsync(id);

            // Devuelve un error si no existe.
            if (producto == null)
            {
                return NotFound(new { mensaje = $"No se encontró un producto con el ID {id}." });
            }

            // Convierte el producto a DTO y lo devuelve.
            var productoDTO = new ProductoDTO
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Stock = producto.Stock
            };

            return Ok(new { mensaje = "Producto obtenido con éxito.", producto = productoDTO });
        }

        // Método para crear un nuevo producto.
        [HttpPost]
        public async Task<ActionResult> CrearProducto(ProductoDTO productoDTO)
        {
            // Devuelve un error si no se ingresan los datos correctos.
            if (string.IsNullOrWhiteSpace(productoDTO.Nombre) || productoDTO.Precio <= 0 || productoDTO.Stock < 0)
            {
                return BadRequest(new { mensaje = "Datos inválidos. Verifique que el nombre no esté vacío, el precio sea mayor a 0 y el stock no sea negativo." });
            }

            // Crea un nuevo producto con los datos recibidos.
            var producto = new Producto
            {
                Nombre = productoDTO.Nombre,
                Precio = productoDTO.Precio,
                Stock = productoDTO.Stock
            };

            // Agrega el producto a la base de datos y guarda los cambios.
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            // Devuelve el producto creado con su nuevo id.
            return CreatedAtAction(nameof(ObtenerProductoPorId), new { id = producto.Id }, producto);
        }

        // Método para actualizar un producto existente.
        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarProducto(int id, ProductoDTO productoDTO)
        {
            // Busca el producto en la base de datos.
            var producto = await _context.Productos.FindAsync(id);

            // Devuelve un error si no existe.
            if (producto == null)
            {
                return NotFound(new { mensaje = $"No se encontró un producto con el ID {id}." });
            }

            // Devuelve un error si no se ingresan los datos correctos.
            if (string.IsNullOrWhiteSpace(productoDTO.Nombre) || productoDTO.Precio <= 0 || productoDTO.Stock < 0)
            {
                return BadRequest(new { mensaje = "Datos inválidos. Verifique que el nombre no esté vacío, el precio sea mayor a 0 y el stock no sea negativo." });
            }

            // Actualiza los datos del producto.
            producto.Nombre = productoDTO.Nombre;
            producto.Precio = productoDTO.Precio;
            producto.Stock = productoDTO.Stock;

            // Guarda los cambios en la base de datos.
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Producto actualizado con éxito.", producto });
        }

        // Método para eliminar un producto.
        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarProducto(int id)
        {
            // Busca el producto en la base de datos.
            var producto = await _context.Productos.FindAsync(id);

            // Devuelve un error si no existe.
            if (producto == null)
            {
                return NotFound(new { mensaje = $"No se encontró un producto con el ID {id}." });
            }

            // Elimina el producto de la base de datos y guarda los cambios.
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Producto eliminado con éxito." });
        }
    }
}
