namespace HorasExtras.Domain.Entities
{
    public class Menu: EntityBase<Guid>
    {
        public string Nombre { get; set; } = default!; 
        public string Ruta { get; set; } = default!;
        public string Icono { get; set; } = default!;
    }
}
