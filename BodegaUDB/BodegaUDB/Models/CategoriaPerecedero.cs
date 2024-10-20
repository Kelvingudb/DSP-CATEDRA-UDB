using System;
using System.Collections.Generic;

namespace BodegaUDB.Models;

public partial class CategoriaPerecedero
{
    public int IdPerecedero { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<CategoriaProducto> CategoriaProductos { get; set; } = new List<CategoriaProducto>();
}
