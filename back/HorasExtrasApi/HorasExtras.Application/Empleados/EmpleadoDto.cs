using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorasExtras.Application.Empleados
{
    public class EmpleadoDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Rol { get; set; }
        public string Area { get; set; }
        public DateTime FechaIngreso { get; set; }
    }
}
