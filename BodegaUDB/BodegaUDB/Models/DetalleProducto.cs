using System;
using System.Collections.Generic;

namespace BodegaUDB.Models;

public partial class DetalleProducto
{
    public int IdDetalle { get; set; }

    public int IdProducto { get; set; }

    public string Nombre { get; set; } = null!;

    public DateOnly? FechaCaducidad { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
