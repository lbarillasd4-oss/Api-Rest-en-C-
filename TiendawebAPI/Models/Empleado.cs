using System;
using System.Collections.Generic;

namespace TiendawebAPI.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public int? IdPuesto { get; set; }

    public string? Nombre { get; set; }

    public string? Apellidos { get; set; }

    public DateOnly? FechaContratacion { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual Puesto? IdPuestoNavigation { get; set; }
}
