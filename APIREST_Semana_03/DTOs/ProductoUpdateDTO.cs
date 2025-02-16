namespace APIREST_Semana_03.DTOs
{
    // Clase utilizada para actualizar un producto existente.
    public class ProductoUpdateDTO
    {
        // Identificador del producto que se va a actualizar.
        public int Id { get; set; }

        // Nuevo nombre del producto.
        public string Nombre { get; set; }

        // Nuevo precio del producto.
        public decimal Precio { get; set; }

        // Nueva cantidad en stock.
        public int Stock { get; set; }
    }
}
