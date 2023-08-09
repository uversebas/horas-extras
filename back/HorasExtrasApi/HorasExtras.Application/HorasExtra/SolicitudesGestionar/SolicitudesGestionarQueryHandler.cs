using AutoMapper;
using HorasExtras.Application.HorasExtra.MisSolicitudes;
using HorasExtras.Domain.Services;
using MediatR;

namespace HorasExtras.Application.HorasExtra.SolicitudesGestionar
{
    public class SolicitudesGestionarQueryHandler : IRequestHandler<SolicitudesGestionarQuery, IEnumerable<SolicitudesHorasExtraDto>>
    {
        private readonly IMapper _mapper;
        private readonly ISolicitudesHorasExtraService _solicitudesHorasExtraService;

        public SolicitudesGestionarQueryHandler(IMapper mapper, ISolicitudesHorasExtraService solicitudesHorasExtraService)
        {
            _mapper = mapper;
            _solicitudesHorasExtraService = solicitudesHorasExtraService;
        }

        public async Task<IEnumerable<SolicitudesHorasExtraDto>> Handle(SolicitudesGestionarQuery request, CancellationToken cancellationToken)
        {
            var solicitudes = await _solicitudesHorasExtraService.ObtenerSolicitudesAGestionarAsync(request.ColaboradorId);
            return _mapper.Map<IEnumerable<SolicitudesHorasExtraDto>>(solicitudes);
        }
    }
}
