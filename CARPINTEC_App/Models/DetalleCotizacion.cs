using System;
using System.Collections.Generic;

namespace CARPINTEC_App.Models;

public partial class DetalleCotizacion
{
    public int IdDetalleCotizacion { get; set; }

    public int IdCotizacion { get; set; }

    public int IdProducto { get; set; }

    public int Cantidad { get; set; }

    public string? Medidas { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal Subtotal { get; set; }

    public virtual Cotizacion IdCotizacionNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
