using System.ComponentModel.DataAnnotations;

namespace CARPINTEC_App.Models
{
    public class MovimientoInventario
    {
        [Key]
        public int Id { get; set; }
        public string Tipo { get; set; } = string.Empty; // "Entrada" o "Salida"
        public string NombreProducto { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public string UnidadMedida { get; set; } = string.Empty;
        public string ReferenciaOProyecto { get; set; } = string.Empty; // Ej. "Orden de compra #081" o "Cocina Integral"
        public DateTime FechaMovimiento { get; set; } = DateTime.Now;
    }
}