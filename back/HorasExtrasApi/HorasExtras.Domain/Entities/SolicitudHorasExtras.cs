using HorasExtras.Domain.Enum;

namespace HorasExtras.Domain.Entities
{
    public class SolicitudHorasExtras: EntityBase<Guid>
    {
        public Guid ColaboradorId { get; set; }
        public Colaborador Colaborador { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public int Dias { get; set; }
        public string? Motivo { get; set; }
        public EnumTipoSolicitudHorasExtra Tipo { get; set; }
        public EstadoSolicitudHorasExtras Estado { get; private set; }
        public Guid AprobacionHorasExtrasId { get; set; }
        public AprobacionHorasExtras AprobacionHorasExtras { get; set; }

        public SolicitudHorasExtras()
        {
            Estado = EstadoSolicitudHorasExtras.pendiente;
        }

        public void AprobacionGerente(bool aprobacion, string comentario)
        {
            if (aprobacion)
            {
                Estado = EstadoSolicitudHorasExtras.aprobado;
            }
            else
            {
                Estado = EstadoSolicitudHorasExtras.rechazado;
            }

            AprobacionHorasExtras.AprobarLider(aprobacion, comentario);
            AprobacionHorasExtras.AprobarRRHH(aprobacion, comentario);
        }

        public void AprobacionLider(bool aprobacion, string comentario)
        {
            if (aprobacion && AprobacionHorasExtras.AprobacionRRHH == EstadoSolicitudHorasExtras.aprobado)
            {
                Estado = EstadoSolicitudHorasExtras.aprobado;
            }

            AprobacionHorasExtras.AprobarLider(aprobacion, comentario);
        }

        public void AprobacionRHH(bool aprobacion, string comentario)
        {
            Estado = !aprobacion ? EstadoSolicitudHorasExtras.rechazado : ValidarAprobacionRRHH();
            AprobacionHorasExtras.AprobarRRHH(aprobacion, comentario);
        }

        private EstadoSolicitudHorasExtras ValidarAprobacionRRHH()
        {
            if (AprobacionHorasExtras.AprobacionLider == EstadoSolicitudHorasExtras.aprobado ||
                AprobacionHorasExtras.AprobacionLider == EstadoSolicitudHorasExtras.rechazado)
            {
                return EstadoSolicitudHorasExtras.aprobado;
            }

            return EstadoSolicitudHorasExtras.pendiente;
        }
    }
}
