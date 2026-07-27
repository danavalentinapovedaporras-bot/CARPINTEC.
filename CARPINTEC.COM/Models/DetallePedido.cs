using System;
using System.Collections.Generic;

namespace CARPINTEC.COM.Models;

public partial class DetallePedido
{
    public int IdDetallePedido { get; set; }

    public int IdPedido { get; set; }

    public int IdProducto { get; set; }

    public string Material { get; set; } = null!;

    public int Cantidad { get; set; }

    public decimal? Ancho { get; set; }

    public decimal? Alto { get; set; }

    public decimal? Profundidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal Subtotal { get; set; }

    public string? Prioridad { get; set; }

    public string? Observaciones { get; set; }

    public virtual Pedido IdPedidoNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
