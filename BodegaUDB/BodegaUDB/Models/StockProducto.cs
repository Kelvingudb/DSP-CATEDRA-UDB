using System;
using System.Collections.Generic;

namespace BodegaUDB.Models;

public partial class StockProducto
{
    public int IdStock { get; set; }

    public string Sku { get; set; } = null!;

    public int IdProducto { get; set; }

    public int IdPasillo { get; set; }

    public virtual Pasillo IdPasilloNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
