namespace HorasExtras.Domain.Entities
{
    public class RolMenu
    {
        public Guid RolId { get; set; }
        public Rol Rol { get; set; }
        public Guid MenuId { get; set; }
        public Menu Menu { get; set; }
    }
}
