namespace APIREST_Semana_03.DTOs
{
    // Clase utilizada para agregar un nuevo producto.
    public class ProductoInsertDTO
    {
        // Nombre del producto.
        public string Nombre { get; set; }

        // Precio del producto.
        public decimal Precio { get; set; }

        // Cantidad inicial en stock.
        public int Stock { get; set; }
    }
}
