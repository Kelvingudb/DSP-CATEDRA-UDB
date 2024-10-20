using System;
using System.Collections.Generic;

namespace BodegaUDB.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public int SerieLote { get; set; }

    public int CategoriaProducto { get; set; }

    public virtual CategoriaProducto CategoriaProductoNavigation { get; set; } = null!;

    public virtual DetalleProducto? DetalleProducto { get; set; }

    public virtual Lote SerieLoteNavigation { get; set; } = null!;

    public virtual ICollection<StockProducto> StockProductos { get; set; } = new List<StockProducto>();
}
