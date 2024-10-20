using System;
using System.Collections.Generic;

namespace BodegaUDB.Models;

public partial class Lote
{
    public int IdLote { get; set; }

    public int NumSerie { get; set; }

    public DateOnly FechaProduccion { get; set; }

    public DateOnly FechaIngreso { get; set; }

    public decimal Precio { get; set; }

    public int IdProveedor { get; set; }

    public virtual Proveedor IdProveedorNavigation { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
