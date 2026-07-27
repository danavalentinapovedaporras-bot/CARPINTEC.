using System;
using System.Collections.Generic;

namespace CARPINTEC.COM.Models;

public partial class Pqr
{
    public int IdPqr { get; set; }

    public string CodigoPqr { get; set; } = null!;

    public int IdCliente { get; set; }

    public string Asunto { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public DateOnly FechaRegistro { get; set; }

    public DateOnly? FechaRespuesta { get; set; }

    public string? Respuesta { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
