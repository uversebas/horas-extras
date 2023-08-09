namespace HorasExtras.Domain.Entities
{
    public class Rol: EntityBase<Guid>
    {
        public string Nombre { get; set; } = default!;

        public string Descripcion { get; set; } = default!;
    }
}
