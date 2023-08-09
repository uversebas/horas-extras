using HorasExtras.Application.Seguridad.IniciarSesion;
using HorasExtras.Application.Seguridad.ObtenerUsuarios;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HorasExtras.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguridadController: ControllerBase
    {
        private readonly IMediator _mediator;

        public SeguridadController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<UsuarioDto>> ObtenerUsuarios()
        {
            return await _mediator.Send(new ObtenerUsuariosQuery());
        }

        [HttpPost("IniciarSesion")]
        public async Task<TokenDto> IniciarSesion(IniciarSesionCommand inicioSesion)
        {
            return await _mediator.Send(inicioSesion);
        }
    }
}
