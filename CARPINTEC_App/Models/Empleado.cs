using System;
using System.Collections.Generic;

namespace CARPINTEC_App.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public int? IdUsuario { get; set; }

    public string Documento { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Cargo { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string? Direccion { get; set; }

    public DateOnly FechaIngreso { get; set; }

    public decimal? Salario { get; set; }

    public string Estado { get; set; } = null!;

    public string? Foto { get; set; }

    public virtual ICollection<Cotizacion> Cotizacions { get; set; } = new List<Cotizacion>();

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<ManoObra> ManoObras { get; set; } = new List<ManoObra>();
}
