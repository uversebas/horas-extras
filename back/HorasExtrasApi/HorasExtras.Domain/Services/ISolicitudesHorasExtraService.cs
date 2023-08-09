using HorasExtras.Domain.Dtos;
using HorasExtras.Domain.Entities;

namespace HorasExtras.Domain.Services
{
    public interface ISolicitudesHorasExtraService
    {
        Task<IEnumerable<SolicitudHorasExtras>> ObtenerMisSolicitudesAsync(string colaboradorId);

        Task<IEnumerable<SolicitudHorasExtras>> ObtenerSolicitudesAGestionarAsync(string colaboradorId);

        Task CrearSolicitud(CrearSolicitudHorasExtras solicitud);

        Task AprobarSolicitud(AprobarSolicitudHorasExtras aprobarSolicitudHorasExtras);
    }
}
