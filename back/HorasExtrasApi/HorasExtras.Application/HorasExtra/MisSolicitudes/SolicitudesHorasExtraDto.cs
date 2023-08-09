namespace HorasExtras.Application.HorasExtra.MisSolicitudes
{
    public class SolicitudesHorasExtraDto
    {
        public Guid Id { get; set; }
        public int Dias { get; set; }
        public string Motivo { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }
        public string AprobacionLider { get; set; }
        public string AprobacionRRHH { get; set; }
        public string? MotivoLider { get; set; }
        public string? MotivoRRHH { get; set; }
        public DateTime FechaSolicitud { get; set; }
    }
}
