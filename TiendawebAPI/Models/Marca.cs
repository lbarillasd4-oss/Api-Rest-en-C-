using System;
using System.Collections.Generic;

namespace TiendawebAPI.Models;

public partial class Marca
{
    public int IdMarcas { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
