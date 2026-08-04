using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CARPINTEC_App.Models
{
    public class DetalleFactura
    {
        [Key]
        public int IdDetalleFactura { get; set; }

        [Required]
        public int IdFactura { get; set; }

        [Required]
        public int IdProducto { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public decimal PrecioUnitario { get; set; }

        [Required]
        public decimal Subtotal { get; set; }

        public string? Observacion { get; set; }

        // Relaciones
        [ForeignKey("IdFactura")]
        public virtual Factura? Factura { get; set; }

        [ForeignKey("IdProducto")]
        public virtual Producto? Producto { get; set; }
    }
}