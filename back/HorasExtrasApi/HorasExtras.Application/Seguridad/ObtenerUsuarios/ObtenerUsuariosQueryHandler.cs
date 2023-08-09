using AutoMapper;
using HorasExtras.Domain.Ports;
using MediatR;

namespace HorasExtras.Application.Seguridad.ObtenerUsuarios
{
    public class ObtenerUsuariosQueryHandler : IRequestHandler<ObtenerUsuariosQuery, IEnumerable<UsuarioDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;
        public ObtenerUsuariosQueryHandler(IMapper mapper, IUsuarioRepository usuarioRepository)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }
        public async Task<IEnumerable<UsuarioDto>> Handle(ObtenerUsuariosQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await _usuarioRepository.ObtenerUsuariosAsync();
            return _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);
        }
    }
}
