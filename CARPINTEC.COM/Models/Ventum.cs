using System;
using System.Collections.Generic;

namespace CARPINTEC.COM.Models;

public partial class Ventum
{
    public int IdVenta { get; set; }

    public string NumeroFactura { get; set; } = null!;

    public int IdPedido { get; set; }

    public int IdCliente { get; set; }

    public DateOnly FechaVenta { get; set; }

    public string MetodoPago { get; set; } = null!;

    public decimal Subtotal { get; set; }

    public decimal Iva { get; set; }

    public decimal Total { get; set; }

    public string Estado { get; set; } = null!;

    public string? Observaciones { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Pedido IdPedidoNavigation { get; set; } = null!;
}
