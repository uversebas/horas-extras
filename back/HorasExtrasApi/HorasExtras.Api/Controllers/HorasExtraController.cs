using HorasExtras.Application.HorasExtra.AprobarSolicitud;
using HorasExtras.Application.HorasExtra.CrearSolicitud;
using HorasExtras.Application.HorasExtra.MisSolicitudes;
using HorasExtras.Application.HorasExtra.SolicitudesGestionar;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HorasExtras.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class HorasExtraController: ControllerBase
    {
        private readonly IMediator _mediator;

        public HorasExtraController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("MisSolicitudes")]
        public async Task<IEnumerable<SolicitudesHorasExtraDto>> ObtenerMisSolicitudes([FromQuery] MisSolicitudesQuery request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet("SolicitudesGestionar")]
        public async Task<IEnumerable<SolicitudesHorasExtraDto>> ObtenerSolicitudesGestionar([FromQuery] SolicitudesGestionarQuery request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost("CrearSolicitud")]
        public async Task CrearSolicitud(CrearSolicitudQuery solicitud)
        {
            await _mediator.Send(solicitud);
        }

        [HttpPost("AprobarSolicitud")]
        public async Task AprobarSolicitud(AprobarSolicitudQuery aprobarSolicitudQuery)
        {
            await _mediator.Send(aprobarSolicitudQuery);
        }
    }
}
