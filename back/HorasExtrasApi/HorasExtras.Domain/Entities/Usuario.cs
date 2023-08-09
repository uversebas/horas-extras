namespace HorasExtras.Domain.Entities
{
    public class Usuario: EntityBase<Guid>
    {
        public string NombreUsuario { get; set; } = default!;

        public byte[] ClaveHash { get; set; } = default!;

        public byte[] Salt { get; set; } = default!;

        public Guid RolId { get; set; }

        public Rol Rol { get; set; }

    }
}
