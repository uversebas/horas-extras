using AutoMapper;
using HorasExtras.Domain.Dtos;
using HorasExtras.Domain.Services;
using MediatR;

namespace HorasExtras.Application.HorasExtra.CrearSolicitud
{
    public class CrearSolicitudQueryHandler : IRequestHandler<CrearSolicitudQuery>
    {
        private readonly IMapper _mapper;
        private readonly ISolicitudesHorasExtraService _solicitudesHorasExtraService;
        public CrearSolicitudQueryHandler(IMapper mapper, ISolicitudesHorasExtraService solicitudesHorasExtraService)
        {
            _mapper = mapper;
            _solicitudesHorasExtraService = solicitudesHorasExtraService;
        }
        
        public async Task Handle(CrearSolicitudQuery request, CancellationToken cancellationToken)
        {
            var solicitud = _mapper.Map<CrearSolicitudHorasExtras>(request);
            await _solicitudesHorasExtraService.CrearSolicitud(solicitud);
        }
    }
}
