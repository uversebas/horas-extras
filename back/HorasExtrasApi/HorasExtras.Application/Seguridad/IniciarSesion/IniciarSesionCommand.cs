using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorasExtras.Application.Seguridad.IniciarSesion
{
    public class IniciarSesionCommand: IRequest<TokenDto>
    {
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
    }
}
