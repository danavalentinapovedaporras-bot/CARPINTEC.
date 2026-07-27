using System;
using System.Collections.Generic;

namespace CARPINTEC.COM.Models;

public partial class ManoObra
{
    public int IdManoObra { get; set; }

    public string CodigoOrden { get; set; } = null!;

    public int IdPedido { get; set; }

    public int IdProducto { get; set; }

    public int IdEmpleado { get; set; }

    public string Proceso { get; set; } = null!;

    public decimal HorasEstimadas { get; set; }

    public decimal? HorasReales { get; set; }

    public decimal CostoHora { get; set; }

    public string Estado { get; set; } = null!;

    public DateOnly? FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    public string? Observaciones { get; set; }

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;

    public virtual Pedido IdPedidoNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
