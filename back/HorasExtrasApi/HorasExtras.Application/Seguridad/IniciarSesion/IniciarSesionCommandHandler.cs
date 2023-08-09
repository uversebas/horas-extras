using HorasExtras.Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorasExtras.Application.Seguridad.IniciarSesion
{
    public class IniciarSesionCommandHandler : IRequestHandler<IniciarSesionCommand, TokenDto>
    {
        private readonly IUsuarioRepository _repositorioUsuario;

        public IniciarSesionCommandHandler(IUsuarioRepository repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }
        public async Task<TokenDto> Handle(IniciarSesionCommand request, CancellationToken cancellationToken)
        {
            var token = await _repositorioUsuario.AutenticarUsuario(request.NombreUsuario, request.Clave);
            return new TokenDto
            {
                Token = token
            };
        }
    }
}
