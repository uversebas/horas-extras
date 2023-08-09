using HorasExtras.Domain.Dtos;
using HorasExtras.Domain.Entities;
using HorasExtras.Domain.Enum;
using HorasExtras.Domain.Exceptions;
using HorasExtras.Domain.Ports;

namespace HorasExtras.Domain.Services
{
    [DomainService]
    public class SolicitudesHorasExtraService : ISolicitudesHorasExtraService
    {
        private ISolicitudHorasExtrasRepository _solicitudHorasExtrasRepository;
        private IColaboradorRepository _colaboradorRepository;
        private IRolRepository _rolRepository;
        private IAreaRepository _areaRepository;

        private const string ROL_ADMINISTRADOR = "Administrador";
        private const string ROL_RRHH = "RRHH";
        private const string ROL_LIDER = "Lider";
        public SolicitudesHorasExtraService(ISolicitudHorasExtrasRepository solicitudHorasExtrasRepository,
            IColaboradorRepository colaboradorRepository,
            IRolRepository rolRepository,
            IAreaRepository areaRepository)
        {
            _solicitudHorasExtrasRepository = solicitudHorasExtrasRepository;
            _colaboradorRepository = colaboradorRepository;
            _rolRepository = rolRepository;
            _areaRepository = areaRepository;
        }

        public async Task CrearSolicitud(CrearSolicitudHorasExtras solicitud)
        {
            var colaborador = await _colaboradorRepository.ObtenerColaborador(Guid.Parse(solicitud.ColaboradorId), "Area");

            if (colaborador is null)
            {
                throw new HorasExtrasException("No existe el colaborador");
            }

            if (solicitud.TipoSolicitud == EnumTipoSolicitudHorasExtra.dinero)
            {
                await ValidarCantidadDiasEnDinero(colaborador.Id, solicitud.CantidadDias);
            }

            var solicitudHorasExtra = new SolicitudHorasExtras
            {
                ColaboradorId = colaborador.Id,
                Dias = solicitud.CantidadDias,
                Tipo = solicitud.TipoSolicitud,
                FechaSolicitud = DateTime.Now,
                Motivo = solicitud.Motivo,
                AprobacionHorasExtras = new AprobacionHorasExtras
                {
                    LiderId = colaborador.Area.LiderId,
                }
            };

            await _solicitudHorasExtrasRepository.CrearSolicitud(solicitudHorasExtra);

        }

        public async Task<IEnumerable<SolicitudHorasExtras>> ObtenerMisSolicitudesAsync(string colaboradorId)
        {
            var colaborador = await _colaboradorRepository.ObtenerColaborador(Guid.Parse(colaboradorId));

            if (colaborador == null)
            {
                throw new HorasExtrasException("No existe el colaborador");
            }

            return await _solicitudHorasExtrasRepository.ObtenerMisSolicitudesAsync(colaborador.Id);
        }

        public async Task<IEnumerable<SolicitudHorasExtras>> ObtenerSolicitudesAGestionarAsync(string colaboradorId)
        {
            var colaborador = await _colaboradorRepository.ObtenerColaborador(Guid.Parse(colaboradorId), "Area,Usuario");

            if (colaborador is null)
            {
                throw new HorasExtrasException("No existe el colaborador");
            }

            var rol = await _rolRepository.ObtenerRol(colaborador.Usuario.RolId);

            return ValidarRolesAdministradorRRHH(rol) ? await _solicitudHorasExtrasRepository.ObtenerSolicitudesPendientesAsync() :
                await ObtenerSolicitudesAgestionarLiderAsync(colaborador);


        }

        private async Task<IEnumerable<SolicitudHorasExtras>> ObtenerSolicitudesAgestionarLiderAsync(Colaborador colaborador)
        {
            var area = await _areaRepository.ObtenerAreaPorLider(colaborador.Id);
            if (area is null)
            {
                throw new HorasExtrasException("El lider no tiene ara asignada");
            }

            return await _solicitudHorasExtrasRepository.ObtenerSolicitudesPendientesPorLiderAreaAsync(area.Id);
        }

        public async Task AprobarSolicitud(AprobarSolicitudHorasExtras aprobarSolicitudHorasExtras)
        {
            var solicitud = await _solicitudHorasExtrasRepository.ObtenerSolicitudPorIdAsync(Guid.Parse(aprobarSolicitudHorasExtras.SolicitudId));

            if (solicitud is null)
            {
                throw new HorasExtrasException("No existe la solicitud");
            }

            if (solicitud.Estado != EstadoSolicitudHorasExtras.pendiente)
            {
                throw new HorasExtrasException("La solicitud ya fue gestionada anteriormente");
            }

            var colaborador = await _colaboradorRepository.ObtenerColaborador(Guid.Parse(aprobarSolicitudHorasExtras.ColaboradorId), "Area,Usuario");

            if (colaborador is null)
            {
                throw new HorasExtrasException("No existe el colaborador");
            }

            var rol = await _rolRepository.ObtenerRol(colaborador.Usuario.RolId);

            GestionarSolicitud(solicitud, rol, aprobarSolicitudHorasExtras);

            await _solicitudHorasExtrasRepository.ActualizarSolicitudAsync(solicitud);
        }

        private void GestionarSolicitud(SolicitudHorasExtras solicitud, Rol rol, AprobarSolicitudHorasExtras aprobarSolicitudHorasExtras)
        {
            switch (rol.Nombre)
            {
                case ROL_ADMINISTRADOR:
                    solicitud.AprobacionGerente(aprobarSolicitudHorasExtras.Aprobado, aprobarSolicitudHorasExtras.Comentario);
                    break;
                case ROL_RRHH:
                    solicitud.AprobacionRHH(aprobarSolicitudHorasExtras.Aprobado, aprobarSolicitudHorasExtras.Comentario);
                    break;
                case ROL_LIDER:
                    solicitud.AprobacionLider(aprobarSolicitudHorasExtras.Aprobado, aprobarSolicitudHorasExtras.Comentario);
                    break;
                default:
                    break;
            }
        }

        private async Task ValidarCantidadDiasEnDinero(Guid colaboradorId, int cantidadDiasSolicitados)
        {
            var solicitudesDineroDelMes = await _solicitudHorasExtrasRepository.ObtenerSolicitudesDelMesAsync(colaboradorId, EnumTipoSolicitudHorasExtra.dinero);
            var cantidadDias = solicitudesDineroDelMes.Sum(s => s.Dias) + cantidadDiasSolicitados;
            if (cantidadDias > 40)
            {
                throw new HorasExtrasException("Ya ha solicitado al menos 40 días en dinero en este mes.");
            }
        }

        private bool ValidarRolesAdministradorRRHH(Rol rol)
        {
            return rol.Nombre == ROL_ADMINISTRADOR || rol.Nombre == ROL_RRHH;
        }
    }
}
