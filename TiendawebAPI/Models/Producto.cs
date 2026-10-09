using System;
using System.Collections.Generic;

namespace TiendawebAPI.Models;

public partial class Producto
{
    public int IdProductos { get; set; }

    public int? IdMarca { get; set; }

    public string? Nombre { get; set; }

    public float? Precio { get; set; }

    public int? Stock { get; set; }

    public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; } = new List<DetalleFactura>();

    public virtual Marca? IdMarcaNavigation { get; set; }
}
