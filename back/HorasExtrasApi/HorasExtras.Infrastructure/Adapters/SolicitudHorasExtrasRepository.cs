using HorasExtras.Domain.Entities;
using HorasExtras.Domain.Enum;
using HorasExtras.Domain.Ports;

namespace HorasExtras.Infrastructure.Adapters
{
    public class SolicitudHorasExtrasRepository : ISolicitudHorasExtrasRepository
    {
        private readonly IGenericRepository<SolicitudHorasExtras> _repository;

        public SolicitudHorasExtrasRepository(IGenericRepository<SolicitudHorasExtras> repository)
        {
            _repository = repository;
        }

        public async Task CrearSolicitud(SolicitudHorasExtras solicitudHorasExtra)
        {
            await _repository.AddAsync(solicitudHorasExtra);
        }

        public async Task<IEnumerable<SolicitudHorasExtras>> ObtenerMisSolicitudesAsync(Guid colaboradorId)
        {
            return await _repository.GetAsync(s => s.ColaboradorId == colaboradorId, includeProperties: "AprobacionHorasExtras");
        }

        public async Task<IEnumerable<SolicitudHorasExtras>> ObtenerSolicitudesDelMesAsync(Guid colaboradorId, EnumTipoSolicitudHorasExtra tipo)
        {
            var mesActual = DateTime.Now.Month;
            return await _repository.GetAsync(s => s.ColaboradorId == colaboradorId && s.FechaSolicitud.Month == mesActual);
        }

        public async Task<IEnumerable<SolicitudHorasExtras>> ObtenerSolicitudesPendientesAsync()
        {
            return await _repository.GetAsync((s => 
                    s.Estado == EstadoSolicitudHorasExtras.pendiente && s.AprobacionHorasExtras.AprobacionRRHH == EstadoSolicitudHorasExtras.pendiente),
                    includeProperties: "AprobacionHorasExtras");
        }

        public async Task<IEnumerable<SolicitudHorasExtras>> ObtenerSolicitudesPendientesPorLiderAreaAsync(Guid areaId)
        {
            return await _repository.GetAsync((s => 
                    (s.Estado == EstadoSolicitudHorasExtras.pendiente && s.AprobacionHorasExtras.AprobacionLider == EstadoSolicitudHorasExtras.pendiente) &&
                    s.Colaborador.AreaId == areaId), includeProperties: "AprobacionHorasExtras,Colaborador");
        }

        public async Task<SolicitudHorasExtras> ObtenerSolicitudPorIdAsync(Guid id)
        {
            var solicitudes = await _repository.GetAsync(s => s.Id == id, includeProperties: "AprobacionHorasExtras");
            return solicitudes.FirstOrDefault();
        }

        public async Task ActualizarSolicitudAsync(SolicitudHorasExtras solicitudHorasExtras)
        {
            await _repository.UpdateAsync(solicitudHorasExtras);
        }
    }
}
