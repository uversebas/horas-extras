using HorasExtras.Domain.Entities;
using System.Security.Cryptography;
using System.Text;

namespace HorasExtras.Infrastructure.Seeds
{
    public static class UsuarioSeed
    {
        
        public static Dictionary<string,string> NombresUsuarios()
        {

            var usuarios = new Dictionary<string, string>
            {
                { "sebastian.rodriguez@ceiba.com.co", "test123*" },
                { "test.test@ceiba.com.co", "test123*" }
            };
            return usuarios;
        }


        public static IEnumerable<Rol> ObtenerRoles()
        {
            return new List<Rol>
            {
                new Rol
                {
                    Id = Guid.NewGuid(),
                    Nombre = "Administrador",
                    Descripcion = "Rol de administrador"
                },
                new Rol
                {
                    Id = Guid.NewGuid(),
                    Nombre = "Lider",
                    Descripcion = "Rol de lider"
                },
                new Rol
                {
                    Id= Guid.NewGuid(),
                    Nombre = "RRHH",
                    Descripcion = "Rol de recursos humanos"
                },
                new Rol
                {
                    Id = Guid.NewGuid(),
                    Nombre = "Colaborador",
                    Descripcion = "Rol de colaborador"
                }
            };
        }

        public static IEnumerable<Usuario> ObtenerUsuariosSeed(IEnumerable<Rol> roles)
        {
            
            var usuarios = new List<Usuario>();
            foreach (var usuario in NombresUsuarios())
            {
                CreatePasswordHash(usuario.Value, out byte[] passwordHash, out byte[] salt);
                usuarios.Add(new Usuario
                {
                    Id = Guid.NewGuid(),
                    NombreUsuario = usuario.Key,
                    ClaveHash = passwordHash,
                    Salt = salt,
                    RolId = roles.First(r => r.Nombre.Equals("Administrador")).Id
                });
            }

            return usuarios.AsEnumerable();
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] salt)
        {
            using var hmac = new HMACSHA512();
            salt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}
