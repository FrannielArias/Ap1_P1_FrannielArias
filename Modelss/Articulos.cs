using System.ComponentModel.DataAnnotations;

namespace Ap1_P1_FrannielArias.Modelss
{
    public class Articulos
    {
        [Key]
        public int ArticuloId { get; set; }

        [Required(ErrorMessage = "Debe ingresar una descripcion.")]
        public string? Descripcion { get; set; }

        [RegularExpression("^[0-9]+$", ErrorMessage = "El costo debe ser mayor a 0 o es superior al soportado por el sistema")]
        [Range(minimum:0.1, maximum:99999999999999)]
        public Decimal Costo { get; set; }

        [RegularExpression("^[0-9]+$", ErrorMessage = "El porcentaje de ganancia debe ser mayor a 0 o es superior al soportado por el sistema")]
        [Range(minimum: 0.1, maximum: 99999999999999)]
        public Decimal Ganancia { get; set;}

        [RegularExpression("^[0-9]+$", ErrorMessage = "El precio de venta debe ser mayor a 0 o es superior al soportado por el sistema")]
        [Range(minimum: 0.1, maximum: 99999999999999)]
        public Decimal Venta {  get; set; }
        
    }
}
