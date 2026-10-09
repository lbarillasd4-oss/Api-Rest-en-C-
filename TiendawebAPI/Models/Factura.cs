using System;
using System.Collections.Generic;

namespace TiendawebAPI.Models;

public partial class Factura
{
    public int IdFactura { get; set; }

    public int? IdCliente { get; set; }

    public int? IdEmpleado { get; set; }

    public DateTime? Fecha { get; set; }

    public float? Total { get; set; }

    public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; } = new List<DetalleFactura>();

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Empleado? IdEmpleadoNavigation { get; set; }
}
