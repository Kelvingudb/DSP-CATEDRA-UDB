using System;
using System.Collections.Generic;

namespace BodegaUDB.Models;

public partial class DetalleEmpleado
{
    public int IdDetalle { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Dui { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public DateOnly FechaRegistro { get; set; }

    public int IdEmpleado { get; set; }

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;
}
