using System;
using System.Collections.Generic;

namespace CARPINTEC_App.Models;

public partial class Cotizacion
{
    public int IdCotizacion { get; set; }

    public string Folio { get; set; } = null!;

    public int IdCliente { get; set; }

    public int IdEmpleado { get; set; }

    public DateOnly Fecha { get; set; }

    public decimal Total { get; set; }

    public string Estado { get; set; } = null!;

    public string? Observaciones { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<DetalleCotizacion> DetalleCotizacions { get; set; } = new List<DetalleCotizacion>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
