using System;
using System.Collections.Generic;

namespace CARPINTEC.COM.Models;

public partial class Pedido
{
    public int IdPedido { get; set; }

    public string CodigoPedido { get; set; } = null!;

    public int IdCotizacion { get; set; }

    public int IdCliente { get; set; }

    public DateOnly FechaSolicitud { get; set; }

    public DateOnly FechaEntrega { get; set; }

    public string Estado { get; set; } = null!;

    public decimal ValorTotal { get; set; }

    public string? Observaciones { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Cotizacion IdCotizacionNavigation { get; set; } = null!;

    public virtual ICollection<ManoObra> ManoObras { get; set; } = new List<ManoObra>();

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
