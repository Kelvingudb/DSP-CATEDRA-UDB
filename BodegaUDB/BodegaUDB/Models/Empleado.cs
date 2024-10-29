using System;
using System.Collections.Generic;

namespace BodegaUDB.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string Usuario { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int IdDetalleEmpleado { get; set; }

    public virtual DetalleEmpleado IdDetalleEmpleadoNavigation { get; set; } = null!;

    public virtual UserRol? UserRol { get; set; }
}
