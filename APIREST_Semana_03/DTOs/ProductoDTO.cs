namespace APIREST_Semana_03.DTOs
{
    // Clase que se usa para enviar y recibir información de un producto.
    public class ProductoDTO
    {
        // Identificador del producto.
        public int Id { get; set; }

        // Nombre del producto.
        public string Nombre { get; set; }

        // Precio del producto.
        public decimal Precio { get; set; }

        // Cantidad disponible en stock.
        public int Stock { get; set; }
    }
}
