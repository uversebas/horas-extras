using HorasExtras.Application.Empleados;
using HorasExtras.Application.Empleados.Crear;
using HorasExtras.Application.Empleados.ObtenerLideres;
using HorasExtras.Domain.Utils;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HorasExtras.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class EmpleadosController:ControllerBase
    {
        private readonly IMediator _mediator;

        public EmpleadosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<LiderDto> ObtenerLideres()
        {
            return new LiderDto { Apellido = "test" };
        }

        [HttpPost]
        [Authorize(Roles = "Gerente")]
        public async Task<EmpleadoDto> CrearEmpleado(CrearEmpleadoCommand solicitudCreacion)
        {
            return await _mediator.Send(solicitudCreacion);
        }
    }
}
