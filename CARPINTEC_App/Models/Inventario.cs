using System;
using System.Collections.Generic;

namespace CARPINTEC_App.Models;

public partial class Inventario
{
    public int IdInventario { get; set; }

    public int IdProducto { get; set; }

    public int StockActual { get; set; }

    public int StockMinimo { get; set; }

    public string UnidadMedida { get; set; } = null!;

    public decimal PrecioCompra { get; set; }

    public string? Ubicacion { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime? FechaActualizacion { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
