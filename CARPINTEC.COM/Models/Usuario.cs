using System;
using System.Collections.Generic;

namespace CARPINTEC.COM.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string? Correo { get; set; }

    public string Contraseña { get; set; } = null!;

    public string? Rol { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
