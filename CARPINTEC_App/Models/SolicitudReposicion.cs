using System.ComponentModel.DataAnnotations;

namespace CARPINTEC_App.Models
{
    public class SolicitudReposicion
    {
        [Key]
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }

        // Agregamos '?' para evitar advertencias de nulabilidad
        public string? Motivo { get; set; }
        public string? Prioridad { get; set; }
        public string? Proveedor { get; set; }
        public DateTime? FechaRequerida { get; set; }
        public string? Observaciones { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}