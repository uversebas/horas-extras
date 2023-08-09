using HorasExtras.Domain.Enum;

namespace HorasExtras.Domain.Dtos
{
    public class CrearSolicitudHorasExtras
    {
        public string ColaboradorId { get; set; }

        public EnumTipoSolicitudHorasExtra TipoSolicitud { get; set; }

        public int CantidadDias { get; set; }

        public string Motivo { get; set; }
    }
}
