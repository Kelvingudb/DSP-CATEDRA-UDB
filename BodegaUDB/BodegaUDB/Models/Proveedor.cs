using System;
using System.Collections.Generic;

namespace BodegaUDB.Models;

public partial class Proveedor
{
    public int IdProveedor { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public virtual ICollection<Lote> Lotes { get; set; } = new List<Lote>();
}
