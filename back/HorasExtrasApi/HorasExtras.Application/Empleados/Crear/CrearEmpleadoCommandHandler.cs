using AutoMapper;
using HorasExtras.Domain.Entities;
using HorasExtras.Domain.Ports;
using HorasExtras.Domain.Services;
using MediatR;

namespace HorasExtras.Application.Empleados.Crear
{
    public class CrearEmpleadoCommandHandler : IRequestHandler<CrearEmpleadoCommand, EmpleadoDto>
    {
        private readonly IMapper _mapper;
        private readonly IEmpleadoService _servicioEmpleado;
        private readonly IUsuarioRepository _repositorioUsuario;

        public CrearEmpleadoCommandHandler(IMapper mapper, IEmpleadoService servicioEmpleado, IUsuarioRepository repositorioUsuario)
        {
            _mapper = mapper;
            _servicioEmpleado = servicioEmpleado;
            _repositorioUsuario = repositorioUsuario;
        }

        public async Task<EmpleadoDto> Handle(CrearEmpleadoCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _repositorioUsuario.CrearUsuario(request.NombreUsuario, request.Clave, request.RolId);
            var colaborador = _mapper.Map<Colaborador>(request);
            colaborador.UsuarioId = usuario.Id;
            var nuevoEmpleado = await _servicioEmpleado.RegistrarNuevoColaborador(colaborador, request.RolId);
            var respuesta =  _mapper.Map<EmpleadoDto>(nuevoEmpleado);
            respuesta.Area = colaborador.Area.Nombre;
            return respuesta;
        }
    }
}
