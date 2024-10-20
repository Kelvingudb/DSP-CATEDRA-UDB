using System;
using System.Collections.Generic;

namespace BodegaUDB.Models;

public partial class CategoriaPasillo
{
    public int IdCategoria { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Pasillo> Pasillos { get; set; } = new List<Pasillo>();
}
