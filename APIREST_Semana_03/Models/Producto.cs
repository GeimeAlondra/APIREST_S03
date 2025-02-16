using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIREST_Semana_03.Models
{
    public class Producto
    {
        // Identificador único para cada objeto, se genera automáticamente.
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Nombre del producto, es obligatorio y no puede tener más de 100 caracteres.
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        // Precio del producto, debe ser obligatorio y mayor a 0.
        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Precio { get; set; }

        // Cantidad disponible en stock, no puede ser un número negativo.
        [Required]
        [Range(0, double.MaxValue)]
        public int Stock { get; set; }
    }
}
