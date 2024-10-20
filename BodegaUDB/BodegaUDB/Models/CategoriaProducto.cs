using System;
using System.Collections.Generic;

namespace BodegaUDB.Models;

public partial class CategoriaProducto
{
    public int IdCategoria { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public int IdPerecedero { get; set; }

    public virtual CategoriaPerecedero IdPerecederoNavigation { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
