using System;
using System.Collections.Generic;

namespace ToDoList.Models;

public partial class TbTarea
{
    public int TareaPkId { get; set; }

    public string Descripcion { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }
}
