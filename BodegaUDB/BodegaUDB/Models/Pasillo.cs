using System;
using System.Collections.Generic;

namespace BodegaUDB.Models;

public partial class Pasillo
{
    public int IdPasillo { get; set; }

    public int IdCategoria { get; set; }

    public virtual CategoriaPasillo IdCategoriaNavigation { get; set; } = null!;

    public virtual StockProducto? StockProducto { get; set; }
}
