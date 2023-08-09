using HorasExtras.Domain.Entities;

namespace HorasExtras.Domain.Ports
{
    public interface IUsuarioRepository
    {
        public Task<IEnumerable<Usuario>> ObtenerUsuariosAsync();
        Task<string> AutenticarUsuario(string nombreUsuario, string clave);
        Task<Usuario> CrearUsuario(string nombreUsuario, string clave, Guid rolId);
    }
}
