using HorasExtras.Domain.Entities;
using HorasExtras.Domain.Enum;

namespace HorasExtras.Domain.Ports
{
    public interface ISolicitudHorasExtrasRepository
    {
        Task CrearSolicitud(SolicitudHorasExtras solicitudHorasExtra);
        Task<IEnumerable<SolicitudHorasExtras>> ObtenerMisSolicitudesAsync(Guid colaboradorId);

        Task<IEnumerable<SolicitudHorasExtras>> ObtenerSolicitudesDelMesAsync(Guid colaboradorId, EnumTipoSolicitudHorasExtra tipo);
        Task<IEnumerable<SolicitudHorasExtras>> ObtenerSolicitudesPendientesAsync();

        Task<IEnumerable<SolicitudHorasExtras>> ObtenerSolicitudesPendientesPorLiderAreaAsync(Guid areaId);
        Task<SolicitudHorasExtras> ObtenerSolicitudPorIdAsync(Guid id);

        Task ActualizarSolicitudAsync(SolicitudHorasExtras solicitudHorasExtras);
    }
}
