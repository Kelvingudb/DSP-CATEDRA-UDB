using System;
using System.Collections.Generic;

namespace BodegaUDB.Models;

public partial class UserRol
{
    public int IdAsignacion { get; set; }

    public int IdEmpleado { get; set; }

    public int IdRol { get; set; }

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;

    public virtual Rol IdRolNavigation { get; set; } = null!;
}
