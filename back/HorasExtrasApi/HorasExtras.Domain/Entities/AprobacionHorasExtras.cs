using HorasExtras.Domain.Enum;

namespace HorasExtras.Domain.Entities
{
    public class AprobacionHorasExtras: EntityBase<Guid>
    {
        public Guid? LiderId { get; set; }
        public Guid? AprobadorRRHHId { get; set; }
        public EstadoSolicitudHorasExtras AprobacionLider { get; private set; }
        public EstadoSolicitudHorasExtras AprobacionRRHH { get; private set; }
        public string? MotivoLider { get; private set; }
        public string? MotivoRRHH { get; private set; }
        public Colaborador? AprobadorRRHH { get; set; }
        public Colaborador? Lider { get; set; }

        public AprobacionHorasExtras()
        {
            AprobacionLider = EstadoSolicitudHorasExtras.pendiente;
            AprobacionRRHH = EstadoSolicitudHorasExtras.pendiente;
        }

        public void AprobarLider(bool aprobacion, string comentario)
        {
            AprobacionLider = aprobacion ? EstadoSolicitudHorasExtras.aprobado : EstadoSolicitudHorasExtras.rechazado;
            MotivoLider = comentario;
        }

        public void AprobarRRHH(bool aprobacion, string comentario)
        {
            AprobacionRRHH = aprobacion ? EstadoSolicitudHorasExtras.aprobado : EstadoSolicitudHorasExtras.rechazado;
            MotivoRRHH = comentario;
        }
    }
}
