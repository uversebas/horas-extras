using AutoMapper;
using HorasExtras.Domain.Dtos;
using HorasExtras.Domain.Services;
using MediatR;

namespace HorasExtras.Application.HorasExtra.AprobarSolicitud
{
    public class AprobarSolicitudQueryHandler : IRequestHandler<AprobarSolicitudQuery>
    {
        private readonly IMapper _mapper;
        private readonly ISolicitudesHorasExtraService _solicitudesHorasExtraService;
        public AprobarSolicitudQueryHandler(IMapper mapper, ISolicitudesHorasExtraService solicitudesHorasExtraService)
        {
            _mapper = mapper;
            _solicitudesHorasExtraService = solicitudesHorasExtraService;
        }
        public async Task Handle(AprobarSolicitudQuery request, CancellationToken cancellationToken)
        {
            var solicitud = _mapper.Map<AprobarSolicitudHorasExtras>(request);
            await _solicitudesHorasExtraService.AprobarSolicitud(solicitud);
        }
    }
}
