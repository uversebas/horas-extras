namespace HorasExtras.Application.Seguridad.ObtenerUsuarios
{
    public class UsuarioDto
    {
        public string NombreUsuario { get; set; } = default!;

        public string Clave { get; private set; } = default!;
    }
}
