using HorasExtras.Domain.Entities;

namespace HorasExtras.Domain.Test.DataBuilder
{
    public static class DataBuilder
    {
        public static List<Entities.Colaborador> ObtenerColaboradores()
        {
            return new List<Entities.Colaborador>
            {
                new Entities.Colaborador
                {
                    Nombres = "Colaborador 1",
                    NumeroDocumento = "1234"
                }
            };
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
    }
}
