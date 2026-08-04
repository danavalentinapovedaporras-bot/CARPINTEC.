using System;
using System.Collections.Generic;

namespace CARPINTEC_App.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string TipoCliente { get; set; } = null!;

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? NombreEmpresa { get; set; }

    public string? Documento { get; set; }

    public string Contacto { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Ciudad { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Cotizacion> Cotizacions { get; set; } = new List<Cotizacion>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public virtual ICollection<Pqr> Pqrs { get; set; } = new List<Pqr>();

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
