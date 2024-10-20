using System;
using System.Collections.Generic;

namespace BodegaUDB.Models;

public partial class Rol
{
    public int IdRol { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<UserRol> UserRols { get; set; } = new List<UserRol>();
}
