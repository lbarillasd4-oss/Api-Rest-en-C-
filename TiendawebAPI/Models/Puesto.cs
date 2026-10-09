using System;
using System.Collections.Generic;

namespace TiendawebAPI.Models;

public partial class Puesto
{
    public int IdPuestos { get; set; }

    public string? Nombre { get; set; }

    public float? SalarioBase { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
