using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorasExtras.Application.Empleados.Crear
{
    public class CrearEmpleadoCommand: IRequest<EmpleadoDto>
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NombreUsuario { get; set; }
        public string NumeroDocumento { get; set; }
        public string Clave { get; set; }
        public DateTime FechaIngreso { get; set; }
        public Guid RolId { get; set; }
        public Guid AreaId { get; set; }

    }
}
