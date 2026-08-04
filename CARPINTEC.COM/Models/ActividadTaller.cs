namespace CARPINTEC.COM.Models;

public partial class ActividadTaller
{
    public int IdActividad { get; set; }

    public DateOnly Fecha { get; set; }

    public string Categoria { get; set; } = null!;

    public string Texto { get; set; } = null!;

    public int? IdUsuario { get; set; }

    public DateTime FechaRegistro { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
