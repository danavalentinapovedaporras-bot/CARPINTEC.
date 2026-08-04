using System;
using System.Collections.Generic;

namespace CARPINTEC_App.Models;

public partial class Configuracion
{
    public int IdConfiguracion { get; set; }

    public string NombreEmpresa { get; set; } = null!;

    public string Nit { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Ciudad { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string? SitioWeb { get; set; }

    public string? Logo { get; set; }

    public decimal Iva { get; set; }

    public string Moneda { get; set; } = null!;

    public DateTime? FechaActualizacion { get; set; }
}
