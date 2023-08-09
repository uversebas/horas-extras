using HorasExtras.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorasExtras.Domain.Services
{
    public interface IEmpleadoService
    {
        Task<Colaborador> RegistrarNuevoColaborador(Colaborador nuevoColaborador, Guid rolId);
        Task<List<Colaborador>> ObtenerLideres();
        Task<Area> ObtenerAreaEmpleado(Colaborador empleado);
    }
}
