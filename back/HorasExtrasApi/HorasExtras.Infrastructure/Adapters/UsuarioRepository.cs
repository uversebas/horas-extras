using HorasExtras.Domain.Entities;
using HorasExtras.Domain.Ports;
using HorasExtras.Infrastructure.Config;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace HorasExtras.Infrastructure.Adapters
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IGenericRepository<Usuario> _repositorioUsuario;
        private readonly IColaboradorRepository _repositorioColaborador;
        private readonly JwtConfig _configuracionJwt;
        public UsuarioRepository(IGenericRepository<Usuario> repositorioUsuario, 
            JwtConfig jwtConfig,
            IColaboradorRepository repositorioColaborador)
        {
            _repositorioUsuario = repositorioUsuario;
            _configuracionJwt = jwtConfig;
            _repositorioColaborador = repositorioColaborador;
        }

        public async Task<Usuario> CrearUsuario(string nombreUsuario, string clave, Guid rolId)
        {
            CreatePasswordHash(clave, out byte[] passwordHash, out byte[] salt);

            var usuario = new Usuario
            {
                NombreUsuario = nombreUsuario,
                ClaveHash = passwordHash,
                Salt = salt,
                RolId = rolId
            };
            var usuarioNuevo =  await _repositorioUsuario.AddAsync(usuario);

            return usuarioNuevo;
        }

        public async Task<string> AutenticarUsuario(string nombreUsuario, string clave)
        {
            var usuarios = await _repositorioUsuario.GetAsync(usuario => usuario.NombreUsuario.Equals(nombreUsuario), includeProperties: "Rol");
            var usuario = usuarios.FirstOrDefault();

            if (usuario == null || !VerificarPasswordHash(clave, usuario.ClaveHash, usuario.Salt))
            {
                throw new UnauthorizedAccessException("Falla en autenticacion");
            }
            var colaborador = await _repositorioColaborador.ObtenerColaboradorPorUsuario(usuario.Id);
            if (colaborador == null)
            {
                throw new UnauthorizedAccessException("No existe colaborador para el usuario");
            }
            var token = GenerarToken(usuario, colaborador);
            return token;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] salt)
        {
            using var hmac = new HMACSHA512();
            salt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        private string GenerarToken(Usuario usuario, Colaborador colaborador)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.GivenName, usuario.NombreUsuario),
                new Claim(ClaimTypes.Role, usuario.Rol.Nombre),
                new Claim("idColaborador", colaborador.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuracionJwt.KeyJwt));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = _configuracionJwt.Issuer,
                Audience = _configuracionJwt.Audience,
                Expires = DateTime.UtcNow.AddMinutes(_configuracionJwt.DuracionEnMinutos),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }

        private static bool VerificarPasswordHash(string clave, byte[] claveHash, byte[] salt)
        {
            using var hmac = new HMACSHA512(salt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(clave));

            for(int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != claveHash[i])
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<IEnumerable<Usuario>> ObtenerUsuariosAsync()
        {
            return await _repositorioUsuario.GetAsync();
        }
    }
}
