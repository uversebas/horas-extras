using HorasExtras.Domain.Entities;
using HorasExtras.Domain.Ports;

namespace HorasExtras.Domain.Services
{
    [DomainService]
    public class EmpleadoServices: IEmpleadoService
    {
        private readonly IColaboradorRepository _repositorioColaborador;
        private readonly IRolRepository _rolRepository;


        public EmpleadoServices(IColaboradorRepository repositorioEmpleado, IRolRepository rolRepository)
        {
            _repositorioColaborador = repositorioEmpleado;
            _rolRepository = rolRepository;
        }

        public async Task<List<Colaborador>> ObtenerLideres()
        {
            return await _repositorioColaborador.ObtenerLideres();
        }

        public async Task<Area> ObtenerAreaEmpleado(Colaborador empleado)
        {
            return await _repositorioColaborador.ObtenerAreaColaborador(empleado);
        }

        public async Task<Colaborador> RegistrarNuevoColaborador(Colaborador nuevoColaborador, Guid rolId)
        {
            var rol = await _rolRepository.ObtenerRol(rolId);
            var area = await _repositorioColaborador.ObtenerAreaColaborador(nuevoColaborador);

            if ((!EsGerente(rol) || !EsLiderDeArea(rol)) && area.LiderId == Guid.Empty)
            {
                throw new ArgumentException("El empleado debe tener un líder asociado.");
            }


            if (area.LiderId != Guid.Empty)
            {
                var liderAsignado = await _repositorioColaborador.ObtenerColaborador(area.LiderId);
                if (liderAsignado == null)
                {
                    throw new ArgumentException("El líder asignado no es válido.");
                }
            }

            await _repositorioColaborador.AgregarColaborador(nuevoColaborador);

            nuevoColaborador.Area = area;

            return nuevoColaborador;

        }

        private static bool EsGerente(Rol rol)
        {
            return rol.Nombre.Equals("Gerente");
        }

        private static bool EsLiderDeArea(Rol rol)
        {
            return rol.Equals("Lider");
        }
    }
}
