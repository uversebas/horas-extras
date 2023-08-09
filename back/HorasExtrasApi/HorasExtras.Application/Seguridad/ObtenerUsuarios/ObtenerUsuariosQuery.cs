using MediatR;

namespace HorasExtras.Application.Seguridad.ObtenerUsuarios
{
    public class ObtenerUsuariosQuery : IRequest<IEnumerable<UsuarioDto>>
    {
    }
}
