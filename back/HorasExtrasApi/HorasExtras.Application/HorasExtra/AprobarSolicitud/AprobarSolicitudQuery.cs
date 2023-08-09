using MediatR;

namespace HorasExtras.Application.HorasExtra.AprobarSolicitud
{
    public class AprobarSolicitudQuery: IRequest
    {
        public string SolicitudId { get; set; }

        public string ColaboradorId { get; set; }

        public bool Aprobado { get; set; }

        public string Comentario { get; set; }
    }
}
