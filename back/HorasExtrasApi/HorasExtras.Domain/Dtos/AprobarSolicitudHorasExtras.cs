namespace HorasExtras.Domain.Dtos
{
    public class AprobarSolicitudHorasExtras
    {
        public string SolicitudId { get; set; }

        public string ColaboradorId { get; set; }

        public bool Aprobado { get; set; }

        public string Comentario { get; set; }
    }
}
