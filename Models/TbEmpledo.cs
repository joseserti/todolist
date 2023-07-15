using System;
using System.Collections.Generic;

namespace ToDoList.Models;

public partial class TbEmpledo
{
    public int EmpleadoPkId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;
}
