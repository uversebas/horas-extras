using AutoMapper;
using HorasExtras.Domain.Services;
using MediatR;

namespace HorasExtras.Application.HorasExtra.MisSolicitudes
{
    public class MisSolicitudesQueryHandler : IRequestHandler<MisSolicitudesQuery, IEnumerable<SolicitudesHorasExtraDto>>
    {
        private readonly IMapper _mapper;
        private readonly ISolicitudesHorasExtraService _solicitudesHorasExtraService;
        public MisSolicitudesQueryHandler(IMapper mapper, ISolicitudesHorasExtraService solicitudesHorasExtraService)
        {
            _mapper = mapper;
            _solicitudesHorasExtraService = solicitudesHorasExtraService;
        }
        public async Task<IEnumerable<SolicitudesHorasExtraDto>> Handle(MisSolicitudesQuery request, CancellationToken cancellationToken)
        {
            var solicitudes = await _solicitudesHorasExtraService.ObtenerMisSolicitudesAsync(request.ColaboradorId);
            return _mapper.Map<IEnumerable<SolicitudesHorasExtraDto>>(solicitudes);
        }
    }
}
