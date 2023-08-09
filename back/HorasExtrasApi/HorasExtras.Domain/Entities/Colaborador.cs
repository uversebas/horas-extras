namespace HorasExtras.Domain.Entities
{
    public class Colaborador: EntityBase<Guid>
    {
        public string NumeroDocumento { get; set; }
        public string Nombres { get; set; }
        public string Apellido { get; set; }
        public Guid AreaId { get; set; }
        public Guid UsuarioId { get; set; }        
        public DateTime FechaIngreso { get; set; }        
        public Area Area { get; set; }
        public Usuario Usuario { get; set; }
    }
}
